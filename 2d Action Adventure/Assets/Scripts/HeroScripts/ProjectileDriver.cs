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
			rigidbody2D.velocity = transform.right * projectileSpeed;
		else
		{
			rigidbody2D.velocity = -transform.right * projectileSpeed;
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
		}
	}

}
