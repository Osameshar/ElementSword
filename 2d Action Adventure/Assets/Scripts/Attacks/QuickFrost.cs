﻿using UnityEngine;
using System.Collections;

public class QuickFrost : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;

	
	public QuickFrost()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();
		
		nextAttack = "QuickPoison";
		previousAttack = "QuickFire";
		damage = 10;
		
	}

	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFrostDebuff());
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