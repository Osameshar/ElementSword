using UnityEngine;
using System.Collections;

public class QuickWind : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private Attack projectileMode;

	public QuickWind()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		projectileMode = new ProjectileWind ();
		nextAttack = "QuickFire";
		previousAttack = "QuickPoison";
		damage = 10;
	}
	
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, null);
		player.GetComponent<BuffDebuffManager> ().AddBuffDebuff (new QuickWindBuff());
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
