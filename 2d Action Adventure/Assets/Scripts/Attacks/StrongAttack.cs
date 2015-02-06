using UnityEngine;
using System.Collections;

public class StrongAttack : Attack
{
	private float damage;
	private string name;

	public StrongAttack()
	{
		name = "StrongAttack";
		damage = 10;		
	}

	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, null);
		player.GetComponent<CombatManager> ().GetEquippedSpells ().CastSpell (enemy, player, enemy.GetComponent<BuffDebuffManager> ().GetElementStacks ());
		enemy.GetComponent<BuffDebuffManager> ().ClearStacks ();
	}
}
