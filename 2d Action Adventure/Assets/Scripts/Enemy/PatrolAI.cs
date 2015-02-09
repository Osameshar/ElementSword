using UnityEngine;
using System.Collections;

public class PatrolAI : MonoBehaviour
{
	Vector3 originalPosition;
	public float distance;//distance to patrol
	private float speed;
	Stats stats;

	bool isGoingLeft = false;
	// Use this for initialization
	void Start () {
		stats = GetComponent<Stats> ();
		originalPosition = transform.position;
	}
	
	// Update is called once per frame

	
	void Update()
	{    
		float distFromStart = transform.position.x - originalPosition.x;   
		speed = stats.getSpeed() * stats.getMovementModifier();
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
