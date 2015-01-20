using UnityEngine;
using System.Collections;

public class SwordHitBoxTrigger : MonoBehaviour 
{
	private HeroStats heroStats;
	void Start() 
	{
		GameObject go = GameObject.Find ("Hero");
		heroStats = (HeroStats) go.GetComponent(typeof(HeroStats));
	}


	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy")
		{
			Stats currentStats;
			currentStats = (Stats) other.GetComponent(typeof(Stats));
			currentStats.takeDamage (heroStats.damage, heroStats.elementType , heroStats.attackType);
		}
	}
}
