using UnityEngine;
using System.Collections;

public class StrongAttack : Attack
{
	private float damage;

	public StrongAttack()
	{
		damage = 10;		
	}

	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, null);
		player.GetComponent<CombatManager> ().GetEquippedSpells ().CastSpell (enemy, player, enemy.GetComponent<BuffDebuffManager> ().GetElementStacks ());
	}
}
