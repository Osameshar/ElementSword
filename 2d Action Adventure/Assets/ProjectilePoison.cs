using UnityEngine;
using System.Collections;

public class ProjectilePoison : Attack
{
	private float damage;
	
	public ProjectilePoison () 
	{	
		damage = 5;
		
	}
	
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickPoisonDebuff());
	}
}
