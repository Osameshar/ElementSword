using UnityEngine;
using System.Collections;

public class QuickPoison : Attack,DefaultAttack 
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private Attack projectileMode;

	public QuickPoison()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		projectileMode = new ProjectilePoison ();
		nextAttack = "QuickWind";
		previousAttack = "QuickFrost";
		damage = 10;
		
	}
	
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickPoisonDebuff());
	}
	
	public string GetNextAttack()
	{
		return nextAttack;
	}
	
	public string GetPreviousAttack()
	{
		return previousAttack;
	}
	public Attack GetProjectileMode()
	{
		return projectileMode;
	}
}
