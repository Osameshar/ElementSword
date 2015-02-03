using UnityEngine;
using System.Collections;

public class QuickPoisonDebuff : BuffDebuff
{	
	private int remainingDuration;
	private string name;
	private float debuffStrength;

	public QuickPoisonDebuff()
	{
		name = "QuickPoisonDebuff";
		remainingDuration = 10;
		debuffStrength = 5f;//dps
	}

	public int GetRemainingDuration()
	{
		return remainingDuration;
	}

	public string GetName()
	{
		return name;
	}

	public void onApply (Stats stats)
	{
		
	}
	
	public void onSecond (Stats stats)
	{
		stats.gameObject.GetComponent<CombatManagerEnemy>().TakeDamage(debuffStrength,null);
		remainingDuration--;		
	}
	
	public void onEnd(Stats stats)
	{

	}
}
