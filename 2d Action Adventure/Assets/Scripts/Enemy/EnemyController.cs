using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	
	public float distance;//distance to patrol
	
	private Animator anim;
	private Stats stats;
	
	private float speed;
	private int action = 0;
	Vector3 originalPosition;
	bool isGoingLeft = false;
	
	void Start () 
	{
		anim = GetComponent<Animator> ();
		stats = GetComponent<Stats> ();
		originalPosition = transform.position;
		action = 1;
	}
	
	void Update () 
	{
		if (stats.getStunned () == 0) {
					
						speed = stats.getSpeed () * stats.getMovementModifier ();
						anim.SetFloat ("Speed", speed);

						switch (action) {
						case 1:
								{
										isPatrolling ();
										break;
								}
						case 2:
								{
										isChasing ();
										break;
								}
						case 3:
								{
										isReturning ();
										break;
								}
						default:
								{
										break;
								}
						}
				} else 
				{
					isStunned();
				}
	}

	void isStunned()
	{

	}
	void isPatrolling()
	{
		float distFromStart = transform.position.x - originalPosition.x;   
		
		if (isGoingLeft)
		{
			// If gone too far, switch direction
			if (distFromStart < -distance)
				SwitchDirection();
			transform.Translate (new Vector3(Time.deltaTime * speed * -1,0,0));
		}
		else
		{
			// If gone too far, switch direction
			if (distFromStart > distance)
				SwitchDirection();
			
			transform.Translate (new Vector3(Time.deltaTime * speed,0,0));
		}
	}
	
	void isChasing()
	{
		
	}
	void isReturning()
	{
		
	}
	
	void SwitchDirection()
	{
		isGoingLeft = !isGoingLeft;
		Flip ();
		//TODO: Change facing direction, animation, etc
	}
	
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
