﻿using UnityEngine;
using System.Collections;

public class QuickFrostDebuff : BuffDebuff 
{
	private int remainingDuration;
	private string name;
	private float debuffStrength;

	public QuickFrostDebuff()
	{
		name = "QuickFrostDebuff";
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
		stats.movementModifier -= debuffStrength;
	}
	
	public void onSecond (Stats stats)
	{
		remainingDuration--;
	}
	
	public void onEnd(Stats stats)
	{
		stats.movementModifier += debuffStrength;
	}
}
