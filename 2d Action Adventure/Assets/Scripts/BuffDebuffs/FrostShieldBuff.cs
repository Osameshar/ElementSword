using UnityEngine;
using System.Collections;

class FrostShieldBuff : BuffDebuff
{
	private float shieldStrength;
	private float shieldAmount;
	private int remainingDuration;
	private string name;
	private AnimatorController personalAnim;

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
		remainingDuration--;
	}

	public void onEnd (Stats stats)
	{
		stats.alterShield(0);
		personalAnim.FrostShieldAnimation (false);
	}
}

