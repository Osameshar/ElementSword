using UnityEngine;
using System.Collections;

public class QuickAttackHitBoxTrigger : MonoBehaviour 
{
	private CombatManager combat;
	private GameObject player;
	private GameObject gui;
	private EnemyHealthBar bar;
	private StackNumbers stackNum;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
		stackNum = gui.GetComponent<StackNumbers> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			combat.GetCurrentAttack().ExecuteAttack(other.gameObject,player);
			bar.updateGameObject(other.gameObject);
			stackNum.updateIconsOnHit(other.gameObject);
		}
	}

}
