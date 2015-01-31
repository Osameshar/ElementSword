﻿using UnityEngine;
using System.Collections;

public class QuickFire : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;


	public QuickFire()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		nextAttack = "QuickFrost";
		previousAttack = "QuickWind";
		damage = 10;

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

}
