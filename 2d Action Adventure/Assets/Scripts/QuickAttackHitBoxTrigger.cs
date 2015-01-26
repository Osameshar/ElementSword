using UnityEngine;
using System.Collections;

public class QuickAttackHitBoxTrigger : MonoBehaviour 
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
			CombatMechanics cm;
			cm = (CombatMechanics) other.GetComponent(typeof(CombatMechanics));
			cm.takeDamage (heroStats.damage, heroStats.elementType , heroStats.attackType);
		}
	}
}
