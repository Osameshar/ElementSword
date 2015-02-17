using UnityEngine;
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
	
	}
	public float GetDamage()
	{
		return stats.getDamage();
	}
	public void TakeDamage(float damage, BuffDebuff bd)
	{
		if (invulnerable)
			return;
		damage = damage/stats.getToughness();
		stats.alterHealth(damage);//multiply by toughness or whatever formula we need to use
		if(bd != null)
			bdManager.AddBuffDebuff (bd);
	
		invulnerable = true;
		StartCoroutine (InvulnerableTime ());
	}

	IEnumerator InvulnerableTime()
	{
		yield return new WaitForSeconds(timeBetweenDamage);
		invulnerable = false;
	}
}
