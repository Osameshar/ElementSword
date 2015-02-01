using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;
public class AstarAI : MonoBehaviour {
	//The point to move to
	public Transform target;
	
	private Seeker seeker;
	private Rigidbody2D rigidB;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 100;
	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	private bool facingRight = true;

	private float lastRepath = -9999;
	public float repathRate = 0.5F;
	protected bool canSearchAgain = true;
	public bool canSearch = true;
	private bool startHasRun = false;
	protected Vector3 lastFoundWaypointPosition;

	public void Awake () {
		seeker = GetComponent<Seeker>();
		rigidB = GetComponent<Rigidbody2D>();
	}

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
		
		lastFoundWaypointPosition = transform.position;
		
		if (startHasRun) {
			//Make sure we receive callbacks when paths complete
			seeker.pathCallback += OnPathComplete;
			
			StartCoroutine (RepeatTrySearchPath ());
		}
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
		seeker.StartPath (transform.position, targetPosition);
	}
	


	public void OnPathComplete (Path p) {
		
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
		currentWaypoint = 0;

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public void FixedUpdate () {
		if (path == null) {
			//We have no path to move after yet
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			return;
		}
		
		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		rigidB.velocity = new Vector2(dir.x,0);

		if (dir.x > 0 && !facingRight)
			Flip ();
		else if (dir.x < 0 && facingRight)
			Flip ();
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
} 