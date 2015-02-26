using UnityEngine;
using System.Collections;

public class ProjectileFrost : Attack
{
	private float damage;
	private string name;

	public ProjectileFrost () 
	{	
		name = "ProjectileFrost";
		damage = 5;
		
	}

	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, new QuickFrostDebuff(),true);
	}
}
