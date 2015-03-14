using UnityEngine;
using System.Collections;

public class ProjectileDriver : MonoBehaviour 
{
	public float projectileSpeed;
	public bool isFacingRight;
	// Use this for initialization
	void Start () 
	{
		if(isFacingRight)
			GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
		else
		{
			GetComponent<Rigidbody2D>().velocity = -transform.right * projectileSpeed;
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
		}
	}

}
