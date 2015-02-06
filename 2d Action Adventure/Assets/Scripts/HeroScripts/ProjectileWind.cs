using UnityEngine;
using System.Collections;

public class ProjectileWind : Attack
{
	
	private float damage;
	private string name;

	public ProjectileWind () 
	{	
		name = "ProjectileWind";
		damage = 5;		
	}

	public string GetName()
	{
		return name;
	}
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, null);
		player.GetComponent<BuffDebuffManager> ().AddBuffDebuff (new QuickWindBuff());
	}
}
