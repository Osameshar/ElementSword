using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour 
{
	private GameObject player;
	private GameObject gui;
	private EnemyHealthBar bar;
	private CombatManager combat;
	private DefaultAttack Dattack;
	private Attack attack;
	private StackNumbers stackNum;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
		Dattack = (DefaultAttack)combat.GetCurrentAttack();
		attack = Dattack.GetProjectileMode ();
		stackNum = gui.GetComponent<StackNumbers> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Enemy") 
		{
			attack.ExecuteAttack (other.gameObject, player);
			bar.updateGameObject (other.gameObject);
			stackNum.updateIconsOnHit(other.gameObject);
			Destroy(this.gameObject);
		} else
			Destroy (this.gameObject);
	}
}
