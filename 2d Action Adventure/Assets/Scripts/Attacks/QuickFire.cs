using UnityEngine;
using System.Collections;

public class QuickFire : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private Attack projectileMode;
	private string name;

	public QuickFire()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		name = "QuickFire";
		projectileMode = new ProjectileFire ();
		nextAttack = "QuickFrost";
		previousAttack = "QuickWind";
		damage = 10;

	}
	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFireDebuff());
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
