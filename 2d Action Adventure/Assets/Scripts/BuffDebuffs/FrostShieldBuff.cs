using UnityEngine;
using System.Collections;

class FrostShieldBuff : BuffDebuff
{
	private float shieldStrength;
	private float shieldAmount;
	private int remainingDuration;
	private string name;

	public FrostShieldBuff (int stacks)
	{
		shieldStrength = 20f;
		shieldAmount = stacks * shieldStrength;
		remainingDuration = 10;
		name = "FrostShieldBuff";
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
		stats.shield = shieldAmount;
	}

	public void onSecond (Stats stats)
	{
		remainingDuration--;
	}

	public void onEnd (Stats stats)
	{
		stats.shield = 0;
	}
}

