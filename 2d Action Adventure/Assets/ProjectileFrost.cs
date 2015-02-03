using UnityEngine;
using System.Collections;

public class ProjectileFrost : Attack
{
	private float damage;
	
	public ProjectileFrost () 
	{	

		damage = 5;
		
	}
	
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFrostDebuff());
	}
}
