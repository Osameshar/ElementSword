using UnityEngine;
using System.Collections;

public class CombatManagerEnemy : MonoBehaviour 
{
	Stats stats;
	BuffDebuffManager bdManager;

	void Start () 
	{
		stats = GetComponent<Stats> ();
		bdManager = GetComponent<BuffDebuffManager> ();

	}

	void Update () {
	
	}
	public float GetDamage()
	{
		return stats.getDamage();
	}
	public void TakeDamage(float damage, BuffDebuff bd)
	{
		damage = damage/stats.getToughness();
		stats.alterHealth(damage);//multiply by toughness or whatever formula we need to use
		if(bd != null)
			bdManager.AddBuffDebuff (bd);
	}
}
