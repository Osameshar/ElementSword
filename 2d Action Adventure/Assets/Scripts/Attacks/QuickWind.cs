using UnityEngine;
using System.Collections;

public class QuickWind : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private Attack projectileMode;
	private string name;

	public QuickWind()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		name = "QuickWind";
		projectileMode = new ProjectileWind ();
		nextAttack = "QuickFire";
		previousAttack = "QuickPoison";
		damage = 10;
	}

	public string GetName()
	{
		return name;
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
