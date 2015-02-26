using UnityEngine;
using System.Collections;

public class OnCollisionEnemy : MonoBehaviour 
{
	CombatManagerEnemy combatManager;
	private GameObject player;
	// Use this for initialization
	void Start () {
		combatManager = GetComponent<CombatManagerEnemy> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject == player)
		{
			//Vector2 dir = (collision.transform.position - transform.position).normalized; 
			//player.rigidbody2D.AddForce(dir*1000);
			player.GetComponent<CombatManager>().TakeDamage(combatManager.GetDamage(),null,true);
		}
	}
}
