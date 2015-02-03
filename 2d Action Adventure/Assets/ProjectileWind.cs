using UnityEngine;
using System.Collections;

public class ProjectileWind : Attack
{
	
	private float damage;
	
	public ProjectileWind () 
	{	
		damage = 5;		
	}
	
	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		enemy.GetComponent<CombatManagerEnemy> ().TakeDamage (damage, null);
		player.GetComponent<BuffDebuffManager> ().AddBuffDebuff (new QuickWindBuff());
	}
}
