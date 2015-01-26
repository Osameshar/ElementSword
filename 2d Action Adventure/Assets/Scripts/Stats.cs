using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public int health = 100;
	public float attackSpeed = 1f;
	public float moveSpeed = 10f;
	public float jumpForce = 800f;
	public int damage = 10;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {

		CheckDeath ();
	}

	public int getHealth ()
	{
		return health;
	}
	public void setHealth(int newHealth)
	{
		health = newHealth;
	}
	
	public void CheckDeath ()
	{
		if (health <= 0) 
		{
			Destroy(transform.gameObject);
		}
	}

}
