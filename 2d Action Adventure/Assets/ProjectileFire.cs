using UnityEngine;
using System.Collections;

public class ProjectileFire : Attack
{

	private float damage;

	public ProjectileFire () 
	{	
		damage = 5;
	
	}
	
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFireDebuff());
	}
}
