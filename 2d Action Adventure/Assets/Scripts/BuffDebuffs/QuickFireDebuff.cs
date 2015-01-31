using UnityEngine;
using System.Collections;

public class QuickFireDebuff : BuffDebuff
{
	private int baseDuration;
	private int remainingDuration;
	private string name;
	private float debuffStrength;

	public QuickFireDebuff()
	{
		name = "QuickFireDebuff";
		baseDuration = 10;
		remainingDuration = baseDuration;
		debuffStrength = 0.1f;
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
		stats.toughness -= debuffStrength;
	}
	
	public void onSecond (Stats stats)
	{
		remainingDuration--;
	}
	
	public void onEnd(Stats stats)
	{
		//remainingDuration = baseDuration;
		stats.toughness += debuffStrength;
	}
}
