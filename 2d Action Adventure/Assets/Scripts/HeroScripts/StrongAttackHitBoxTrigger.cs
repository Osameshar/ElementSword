using UnityEngine;
using System.Collections;

public class StrongAttackHitBoxTrigger : MonoBehaviour 
{

	private CombatManager combat;
	private GameObject player;
	private EnemyHealthBar bar;
	private GameObject gui;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			combat.GetStrongAttack().ExecuteAttack(other.gameObject,player);
			bar.updateGameObject(other.gameObject);
		}
	}
}
