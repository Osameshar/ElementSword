using UnityEngine;
using System.Collections;

public class StrongAttackHitBoxTrigger : MonoBehaviour 
{

	private CombatManager combat;
	private GameObject player;
	private EnemyHealthBar bar;
	private GameObject gui;
	private Animator anim;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("Attack");
		StartCoroutine (HitBoxLifeTime ());
	}

	IEnumerator HitBoxLifeTime()
	{
		yield return new WaitForSeconds (1f);
		Destroy (this.gameObject);
		
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			combat.GetStrongAttack().ExecuteAttack(other.gameObject,player);
			bar.updateGameObject(other.gameObject);
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
