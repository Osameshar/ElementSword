using UnityEngine;
using System.Collections;

public class QuickPoisonDebuff : BuffDebuff
{	
	private int baseDuration;
	private int remainingDuration;
	private string name;
	private float debuffStrength;

	public QuickPoisonDebuff()
	{
		name = "QuickPoisonDebuff";
		baseDuration = 10;
		remainingDuration = baseDuration;
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
		stats.health -= debuffStrength;
		remainingDuration--;		
	}
	
	public void onEnd(Stats stats)
	{

	}
}
