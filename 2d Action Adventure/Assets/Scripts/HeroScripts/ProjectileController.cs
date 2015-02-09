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
	private Animator projectileAnim;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		combat = player.GetComponent<CombatManager>();
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
		Dattack = (DefaultAttack)combat.GetCurrentAttack();
		attack = Dattack.GetProjectileMode ();
		stackNum = gui.GetComponent<StackNumbers> ();
		projectileAnim = GetComponent<Animator> ();

		UpdateActiveElementVariables (Dattack);
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Enemy") 
		{
			attack.ExecuteAttack (other.gameObject, player);
			bar.updateGameObject (other.gameObject);
			stackNum.updateIconsOnHit(other.gameObject);
		}
		Destroy(this.gameObject);
	}

	public void UpdateActiveElementVariables (Attack currentAttack)
	{
		if (currentAttack.GetName ().Equals ("QuickFire")) 
		{
			projectileAnim.SetBool("FireEquipped",true);
			projectileAnim.SetBool("FrostEquipped",false);
			projectileAnim.SetBool("PoisonEquipped",false);
			projectileAnim.SetBool("WindEquipped",false);
		} 
		else if (currentAttack.GetName ().Equals ("QuickFrost")) 
		{
			projectileAnim.SetBool("FireEquipped",false);
			projectileAnim.SetBool("FrostEquipped",true);
			projectileAnim.SetBool("PoisonEquipped",false);
			projectileAnim.SetBool("WindEquipped",false);
		}
		else if (currentAttack.GetName ().Equals ("QuickPoison")) 
		{
			projectileAnim.SetBool("FireEquipped",false);
			projectileAnim.SetBool("FrostEquipped",false);
			projectileAnim.SetBool("PoisonEquipped",true);
			projectileAnim.SetBool("WindEquipped",false);
		}
		else if (currentAttack.GetName ().Equals ("QuickWind")) 
		{
			projectileAnim.SetBool("FireEquipped",false);
			projectileAnim.SetBool("FrostEquipped",false);
			projectileAnim.SetBool("PoisonEquipped",false);
			projectileAnim.SetBool("WindEquipped",true);
		}
	}
}
