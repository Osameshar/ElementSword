using UnityEngine;
using System.Collections;

public class ProjectilePoison : Attack
{
	private float damage;
	private string name;

	public ProjectilePoison () 
	{	
		name = "ProjectilePoison";
		damage = 5;
		
	}

	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickPoisonDebuff(),true);
	}
}
