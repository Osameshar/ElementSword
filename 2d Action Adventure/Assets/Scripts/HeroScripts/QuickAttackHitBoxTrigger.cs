using UnityEngine;
using System.Collections;

public class QuickAttackHitBoxTrigger : MonoBehaviour 
{
	private CombatManager combat;
	private GameObject player;
	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			combat.GetCurrentAttack().ExecuteAttack(other.gameObject,player);
		}
	}
}
