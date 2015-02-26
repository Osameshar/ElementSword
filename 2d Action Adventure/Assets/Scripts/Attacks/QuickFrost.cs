using UnityEngine;
using System.Collections;

public class QuickFrost : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private Attack projectileMode;
	private string name;

	public QuickFrost()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		name = "QuickFrost";
		projectileMode = new ProjectileFrost ();
		nextAttack = "QuickPoison";
		previousAttack = "QuickFire";
		damage = 10;
		
	}

	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFrostDebuff(),true);
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
