using UnityEngine;
using System.Collections;

public class FireballTrapController : MonoBehaviour {

	private float nextAttack;
	private float attackSpeed;
	public GameObject fireball;
	void Start () {
		nextAttack = 0.0f;
		attackSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CanAttack ()) 
		{	
			attackSpeed = Random.Range(1f,3f);
			attack ();
		}
	}
	void attack()
	{
		Instantiate (fireball, transform.position, transform.rotation);
		nextAttack = Time.time + attackSpeed;
	}
	bool CanAttack()
	{
		if(Time.time > nextAttack)
		{
			return true;
		}
		else
			return false;
	}
}
