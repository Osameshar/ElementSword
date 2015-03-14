﻿using UnityEngine;
using System.Collections;

public class CombatManagerEnemy : MonoBehaviour 
{
	Stats stats;
	BuffDebuffManager bdManager;
	private bool invulnerable = false;
	public float timeBetweenDamage = 1f;

	void Start () 
	{
		stats = GetComponent<Stats> ();
		bdManager = GetComponent<BuffDebuffManager> ();
	}

	void Update () {
		if(stats.getHealth() <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	public float GetDamage()
	{
		return stats.getDamage();
	}
	public void TakeDamage(float damage, BuffDebuff bd, bool activatesInvuln)
	{
		if (invulnerable)
			return;
		damage = damage/stats.getToughness();
		stats.alterHealth(damage);//multiply by toughness or whatever formula we need to use
		if(bd != null)
			bdManager.AddBuffDebuff (bd);
		if(activatesInvuln)
		{
			invulnerable = true;
			StartCoroutine (InvulnerableTime ());
		}
	}

	IEnumerator InvulnerableTime()
	{
		yield return new WaitForSeconds(timeBetweenDamage);
		invulnerable = false;
	}
}
