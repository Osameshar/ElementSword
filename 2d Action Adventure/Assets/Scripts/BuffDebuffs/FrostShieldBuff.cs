using UnityEngine;
using System.Collections;

class FrostShieldBuff : BuffDebuff
{
	private float shieldStrength;
	private float shieldAmount;
	private int remainingDuration;
	private string name;
	private AnimatorController personalAnim;
	private string iconLocation = "Player";
	private string iconName = "FrostShield";

	public FrostShieldBuff (int stacks)
	{
		personalAnim = GameObject.FindGameObjectWithTag ("Player").GetComponent<AnimatorController> ();

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
		stats.alterShield(-shieldAmount);
		personalAnim.FrostShieldAnimation (true);
	}

	public void onSecond (Stats stats)
	{
		if(stats.getShield() <= 0)
		{
			remainingDuration = 0;
		}
		else
		{
			remainingDuration--;
		}
	}

	public void onEnd (Stats stats)
	{
		stats.alterShield(stats.getShield());
		personalAnim.FrostShieldAnimation (false);
	}
	public string GetIconLocation ()
	{
		return iconLocation;
	}
	public string getIconName()
	{
		return iconName;
	}
}

