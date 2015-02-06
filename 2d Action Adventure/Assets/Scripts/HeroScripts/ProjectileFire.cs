using UnityEngine;
using System.Collections;

public class ProjectileFire : Attack
{
	private float damage;
	private string name;

	public ProjectileFire () 
	{	
		name = "ProjectileFire";
		damage = 5;
	
	}

	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFireDebuff());
	}
}
