using UnityEngine;
using System.Collections;

public class SteamFieldBuff : BuffDebuff {

	private int remainingDuration;
	private string name;
	private string iconLocation = "Player";
	private string iconName = "SteamFieldBuff";
	private float healing;

	public SteamFieldBuff (int fireStacks, int frostStacks)
	{
		remainingDuration = 1;
		healing = -10f;
		name = "SteamFieldBuff";
	}

	public int GetRemainingDuration ()
	{
		return remainingDuration;
	}

	public string GetName ()
	{
		return name;
	}

	public void onApply (Stats stats)
	{

	}

	public void onSecond (Stats stats)
	{
		if(stats.getHealth() < 90f)
		{
			stats.alterHealth (healing);
		}
		else if(stats.getHealth() < 100f)
		{
			stats.setHealth(100);
		}
		remainingDuration--;
	}

	public void onEnd (Stats stats)
	{
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
