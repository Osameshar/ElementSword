//#define ASTARDEBUG
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Pathfinding.RVO;

/** AI for following paths.
 * This AI is the default movement script which comes with the A* Pathfinding Project.
 * It is in no way required by the rest of the system, so feel free to write your own. But I hope this script will make it easier
 * to set up movement for the characters in your game. This script is not written for high performance, so I do not recommend using it for large groups of units.
 * \n
 * \n
 * This script will try to follow a target transform, in regular intervals, the path to that target will be recalculated.
 * It will on FixedUpdate try to move towards the next point in the path.
 * However it will only move in the forward direction, but it will rotate around it's Y-axis
 * to make it reach the target.
 * 
 * \section variables Quick overview of the variables
 * In the inspector in Unity, you will see a bunch of variables. You can view detailed information further down, but here's a quick overview.\n
 * The #repathRate determines how often it will search for new paths, if you have fast moving targets, you might want to set it to a lower value.\n
 * The #target variable is where the AI will try to move, it can be a point on the ground where the player has clicked in an RTS for example.
 * Or it can be the player object in a zombie game.\n
 * The speed is self-explanatory, so is turningSpeed, however #slowdownDistance might require some explanation.
 * It is the approximate distance from the target where the AI will start to slow down. Note that this doesn't only affect the end point of the path
 * but also any intermediate points, so be sure to set #forwardLook and #pickNextWaypointDist to a higher value than this.\n
 * #pickNextWaypointDist is simply determines within what range it will switch to target the next waypoint in the path.\n
 * #forwardLook will try to calculate an interpolated target point on the current segment in the path so that it has a distance of #forwardLook from the AI\n
 * Below is an image illustrating several variables as well as some internal ones, but which are relevant for understanding how it works.
 * Note that the #forwardLook range will not match up exactly with the target point practically, even though that's the goal.
 * \shadowimage{aipath_variables.png}
 * This script has many movement fallbacks.
 * If it finds a NavmeshController, it will use that, otherwise it will look for a character controller, then for a rigidbody and if it hasn't been able to find any
 * it will use Transform.Translate which is guaranteed to always work.
 */
[RequireComponent(typeof(Seeker))]
[AddComponentMenu("Pathfinding/AI/AIPath (generic)")]
public class AIPath : MonoBehaviour {
	
	/** Determines how often it will search for new paths. 
	 * If you have fast moving targets or AIs, you might want to set it to a lower value.
	 * The value is in seconds between path requests.
	 */
	public float repathRate = 0.5F;
	
	/** Target to move towards.
	 * The AI will try to follow/move towards this target.
	 * It can be a point on the ground where the player has clicked in an RTS for example, or it can be the player object in a zombie game.
	 */
	public Transform target;
	
	/** Enables or disables searching for paths.
	 * Setting this to false does not stop any active path requests from being calculated or stop it from continuing to follow the current path.
	 * \see #canMove
	 */
	public bool canSearch = true;
	
	/** Enables or disables movement.
	  * \see #canSearch */
	public bool canMove = true;
	
	/** Maximum velocity.
	 * This is the maximum speed in world units per second.
	 */
	public float speed = 3;
	
	/** Rotation speed.
	 * Rotation is calculated using Quaternion.SLerp. This variable represents the damping, the higher, the faster it will be able to rotate.
	 */
	public float turningSpeed = 5;
	
	/** Distance from the target point where the AI will start to slow down.
	 * Note that this doesn't only affect the end point of the path
 	 * but also any intermediate points, so be sure to set #forwardLook and #pickNextWaypointDist to a higher value than this
 	 */
	public float slowdownDistance = 0.6F;
	
	/** Determines within what range it will switch to target the next waypoint in the path */
	public float pickNextWaypointDist = 2;
	
	/** Target point is Interpolated on the current segment in the path so that it has a distance of #forwardLook from the AI.
	  * See the detailed description of AIPath for an illustrative image */
	public float forwardLook = 1;
	
	/** Distance to the end point to consider the end of path to be reached.
	 * When this has been reached, the AI will not move anymore until the target changes and OnTargetReached will be called.
	 */
	public float endReachedDistance = 0.2F;
	
	/** Do a closest point on path check when receiving path callback.
	 * Usually the AI has moved a bit between requesting the path, and getting it back, and there is usually a small gap between the AI
	 * and the closest node.
	 * If this option is enabled, it will simulate, when the path callback is received, movement between the closest node and the current
	 * AI position. This helps to reduce the moments when the AI just get a new path back, and thinks it ought to move backwards to the start of the new path
	 * even though it really should just proceed forward.
	 */
	public bool closestOnPathCheck = true;
	
	protected float minMoveScale = 0.05F;
	
	/** Cached Seeker component */
	protected Seeker seeker;
	
	/** Cached Transform component */
	protected Transform tr;
	
	/** Time when the last path request was sent */
	private float lastRepath = -9999;
	
	/** Current path which is followed */
	protected Path path;
	
	/** Cached CharacterController component */
	protected CharacterController controller;
	
	/** Cached NavmeshController component */
	protected NavmeshController navController;
	
	
	/** Cached Rigidbody component */
	protected Rigidbody2D rigid;
	
	/** Current index in the path which is current target */
	protected int currentWaypointIndex = 0;
	
	/** Holds if the end-of-path is reached
	 * \see TargetReached */
	protected bool targetReached = false;
	
	/** Only when the previous path has been returned should be search for a new path */
	protected bool canSearchAgain = true;

	protected Vector3 lastFoundWaypointPosition;
	protected float lastFoundWaypointTime = -9999;

	/** Returns if the end-of-path has been reached
	 * \see targetReached */
	public bool TargetReached {
		get {
			return targetReached;
		}
	}
	
	/** Holds if the Start function has been run.
	 * Used to test if coroutines should be started in OnEnable to prevent calculating paths
	 * in the awake stage (or rather before start on frame 0).
	 */
	private bool startHasRun = false;
	
	/** Initializes reference variables.
	 * If you override this function you should in most cases call base.Awake () at the start of it.
	  * */

	private bool facingRight = true;

	protected virtual void Awake () {
		seeker = GetComponent<Seeker>();
		
		//This is a simple optimization, cache the transform component lookup
		tr = transform;
		
		//Cache some other components (not all are necessarily there)
		controller = GetComponent<CharacterController>();
		navController = GetComponent<NavmeshController>();
		rigid = GetComponent<Rigidbody2D>();
	}


	/** Starts searching for paths.
	 * If you override this function you should in most cases call base.Start () at the start of it.
	 * \see OnEnable
	 * \see RepeatTrySearchPath
	 */
	protected virtual void Start () {
		startHasRun = true;
		OnEnable ();
	}
	
	/** Run at start and when reenabled.
	 * Starts RepeatTrySearchPath.
	 * 
	 * \see Start
	 */
	protected virtual void OnEnable () {
		
		lastRepath = -9999;
		canSearchAgain = true;

		lastFoundWaypointPosition = GetFeetPosition ();

		if (startHasRun) {
			//Make sure we receive callbacks when paths complete
			seeker.pathCallback += OnPathComplete;
			
			StartCoroutine (RepeatTrySearchPath ());
		}
	}
	
	public void OnDisable () {
		// Abort calculation of path
		if (seeker != null && !seeker.IsDone()) seeker.GetCurrentPath().Error();
		
		// Release current path
		if (path != null) path.Release (this);
		path = null;
		
		//Make sure we receive callbacks when paths complete
		seeker.pathCallback -= OnPathComplete;
	}
	
	/** Tries to search for a path every #repathRate seconds.
	  * \see TrySearchPath
	  */
	protected IEnumerator RepeatTrySearchPath () {
		while (true) {
			float v = TrySearchPath ();
			yield return new WaitForSeconds (v);
		}
	}
	
	/** Tries to search for a path.
	 * Will search for a new path if there was a sufficient time since the last repath and both
	 * #canSearchAgain and #canSearch are true and there is a target.
	 * 
	 * \returns The time to wait until calling this function again (based on #repathRate) 
	 */
	public float TrySearchPath () {
		if (Time.time - lastRepath >= repathRate && canSearchAgain && canSearch && target != null) {
			SearchPath ();
			return repathRate;
		} else {
			//StartCoroutine (WaitForRepath ());
			float v = repathRate - (Time.time-lastRepath);
			return v < 0 ? 0 : v;
		}
	}
	
	/** Requests a path to the target */
	public virtual void SearchPath () {
		
		if (target == null) throw new System.InvalidOperationException ("Target is null");
		
		lastRepath = Time.time;
		//This is where we should search to
		Vector3 targetPosition = target.position;
		
		canSearchAgain = false;
		
		//Alternative way of requesting the path
		//ABPath p = ABPath.Construct (GetFeetPosition(),targetPoint,null);
		//seeker.StartPath (p);
		
		//We should search from the current position
		seeker.StartPath (GetFeetPosition(), targetPosition);
	}
	
	public virtual void OnTargetReached () {
		//End of path has been reached
		//If you want custom logic for when the AI has reached it's destination
		//add it here
		//You can also create a new script which inherits from this one
		//and override the function in that script
	}
	
	/** Called when a requested path has finished calculation.
	  * A path is first requested by #SearchPath, it is then calculated, probably in the same or the next frame.
	  * Finally it is returned to the seeker which forwards it to this function.\n
	  */
	public virtual void OnPathComplete (Path _p) {
		ABPath p = _p as ABPath;
		if (p == null) throw new System.Exception ("This function only handles ABPaths, do not use special path types");
		
		canSearchAgain = true;
		
		//Claim the new path
		p.Claim (this);
		
		// Path couldn't be calculated of some reason.
		// More info in p.errorLog (debug string)
		if (p.error) {
			p.Release (this);
			return;
		}
		
		//Release the previous path
		if (path != null) path.Release (this);
		
		//Replace the old path
		path = p;
		
		//Reset some variables
		currentWaypointIndex = 0;
		targetReached = false;
		
		//The next row can be used to find out if the path could be found or not
		//If it couldn't (error == true), then a message has probably been logged to the console
		//however it can also be got using p.errorLog
		//if (p.error)
		
		if (closestOnPathCheck) {
			Vector3 p1 = Time.time - lastFoundWaypointTime < 0.3f ? lastFoundWaypointPosition : p.originalStartPoint;
			Vector3 p2 = GetFeetPosition ();
			Vector3 dir = p2-p1;
			float magn = dir.magnitude;
			dir /= magn;
			int steps = (int)(magn/pickNextWaypointDist);


			for (int i=0;i<=steps;i++) {
				//CalculateVelocity (p1);
				p1 += dir;
			}

		}
	}
	
	public virtual Vector3 GetFeetPosition () {

		return tr.position;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	public virtual void FixedUpdate () {

		//if (!canMove) { return; }

		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypointIndex]-GetFeetPosition()).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		rigid.velocity = new Vector2(dir.x,0);
		
		if (dir.x > 0 && !facingRight)
			Flip ();
		else if (dir.x < 0 && facingRight)
			Flip ();
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypointIndex]) < pickNextWaypointDist) {
			currentWaypointIndex++;
			return;
		}
	}
}