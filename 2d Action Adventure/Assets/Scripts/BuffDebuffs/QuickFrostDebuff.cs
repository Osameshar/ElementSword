using UnityEngine;
using System.Collections;

public class QuickFrostDebuff : BuffDebuff 
{
	private int baseDuration;
	private int remainingDuration;
	
	public QuickFrostDebuff()
	{
		baseDuration = 10;
		remainingDuration = baseDuration;
	}
	
	public void onApply ()
	{
		
	}
	
	public void onSecond ()
	{
		remainingDuration--;
		if (remainingDuration <= 0) 
		{
			onEnd ();
		}
	}
	
	public void onEnd()
	{
		
	}
}
