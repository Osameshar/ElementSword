using UnityEngine;
using System.Collections;

public class IgniteTheBlight : Spell {

	private int comboCode;
	private bool discovered;
	private string name;
	private float fireMultiplier;
	private float poisonMultiplier;

	public IgniteTheBlight()
	{
		name = "IgniteTheBlight";
		comboCode = 101;
		fireMultiplier = 0f;
		poisonMultiplier = 20f;
	}
	
	public bool IsDiscovered ()
	{
		return discovered;
	}

	public int GetComboCode ()
	{
		return comboCode;
	}

	public void ExecuteAttack (GameObject enemy, GameObject player)
	{
		BuffDebuffManager bdmanager = enemy.GetComponent<BuffDebuffManager> ();
		int fireStacks = bdmanager.GetElementStacks()[0];
		int poisonStacks = bdmanager.GetElementStacks()[2];
		fireMultiplier = fireStacks * .2f;
		float damage = poisonStacks * poisonMultiplier * fireMultiplier;
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, null, true);
	}

	public string GetName ()
	{
		return name;
	}
	
}
