using UnityEngine;
using System.Collections;

public class QuickAttackHitBoxTrigger : MonoBehaviour 
{
	private CombatManager combat;
	private GameObject player;
	private GameObject gui;
	private EnemyHealthBar bar;
	private StackNumbers stackNum;
	private Animator anim;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
		stackNum = gui.GetComponent<StackNumbers> ();
		anim = GetComponent<Animator> ();

		UpdateActiveElementVariables (combat.GetCurrentAttack());
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
			combat.GetCurrentAttack().ExecuteAttack(other.gameObject,player);
			bar.updateGameObject(other.gameObject);
			stackNum.updateIconsOnHit(other.gameObject);
		}
	}

	public void UpdateActiveElementVariables (Attack currentAttack)
	{
		if (currentAttack.GetName ().Equals ("QuickFire")) 
		{
			anim.SetBool("FireEquipped",true);
			anim.SetBool("FrostEquipped",false);
			anim.SetBool("PoisonEquipped",false);
			anim.SetBool("WindEquipped",false);
		} 
		else if (currentAttack.GetName ().Equals ("QuickFrost")) 
		{
			anim.SetBool("FireEquipped",false);
			anim.SetBool("FrostEquipped",true);
			anim.SetBool("PoisonEquipped",false);
			anim.SetBool("WindEquipped",false);
		}
		else if (currentAttack.GetName ().Equals ("QuickPoison")) 
		{
			anim.SetBool("FireEquipped",false);
			anim.SetBool("FrostEquipped",false);
			anim.SetBool("PoisonEquipped",true);
			anim.SetBool("WindEquipped",false);
		}
		else if (currentAttack.GetName ().Equals ("QuickWind")) 
		{
			anim.SetBool("FireEquipped",false);
			anim.SetBool("FrostEquipped",false);
			anim.SetBool("PoisonEquipped",false);
			anim.SetBool("WindEquipped",true);
		}
	}
}
