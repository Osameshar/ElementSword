using UnityEngine;
using System.Collections;

public class QuickFireDebuff : BuffDebuff
{
	private int remainingDuration;
	private string name;
	private float debuffStrength;
	private string iconLocation = "Enemy";
	private string iconName = "Fire";
	public QuickFireDebuff()
	{
		name = "QuickFireDebuff";
		remainingDuration = 10;
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
		stats.alterToughness(-debuffStrength);
	}
	
	public void onSecond (Stats stats)
	{
		remainingDuration--;
	}
	
	public void onEnd(Stats stats)
	{
		//remainingDuration = baseDuration;
		stats.alterToughness(debuffStrength);
	}
	public string GetIconLocation ()
	{
		return iconLocation;
	}
	
	public string getIconName ()
	{
		return iconName;
	}
}
