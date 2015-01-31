using UnityEngine;
using System.Collections;

public class BuffDebuffManager : MonoBehaviour 
{
	private int[] elementStacks;
	private ArrayList currentBuffDebuffs;
	private ArrayList toRemoveBuffDebuffs;
	public Stats stats;

	void Start () 
	{
		stats = GetComponent<Stats> ();
		elementStacks = new int[3]{0,0,0};//FIRE,POISON,FROST
		currentBuffDebuffs = new ArrayList ();
		toRemoveBuffDebuffs = new ArrayList ();
		InvokeRepeating ("EachSecond", 0f, 1.0f);

	}

	void Update()
	{

	}

	public int[] GetElementStacks()
	{
		return elementStacks;
	}
	public void clearStacks()
	{
		elementStacks [0] = 0;
		elementStacks [1] = 0;
		elementStacks [2] = 0;
	}
	void EachSecond()
	{
		foreach (BuffDebuff bd in currentBuffDebuffs) 
		{
			bd.onSecond(stats);

			if(bd.GetRemainingDuration() <= 0)
			{
				switch(bd.GetName())
				{
				case "QuickFireDebuff":
				{
					elementStacks[0]--;
					bd.onEnd(stats);
					break;
				}
				case "QuickFrostDebuff":
				{
					elementStacks[1]--;
					bd.onEnd(stats);
					break;
				}
				case "QuickPoisonDebuff":
				{
					elementStacks[2]--;
					bd.onEnd(stats);
					break;
				}
				default:
					bd.onEnd(stats);
					break;
					
				}
				toRemoveBuffDebuffs.Add(bd);
			}
		}
		foreach (BuffDebuff bd in toRemoveBuffDebuffs) 
		{
			currentBuffDebuffs.Remove (bd);
		}
		toRemoveBuffDebuffs.Clear ();
	}

	public void AddBuffDebuff(BuffDebuff bd)
	{
		currentBuffDebuffs.Add (bd);
		switch(bd.GetName())
		{
			case "QuickFireDebuff":
			{
				elementStacks[0]++;
				bd.onApply(stats);
				break;
			}
			case "QuickFrostDebuff":
			{
				elementStacks[1]++;
				bd.onApply(stats);
				break;
			}
			case "QuickPoisonDebuff":
			{
				elementStacks[2]++;
				bd.onApply(stats);
				break;
			}
			default:
				bd.onApply(stats);
				break;

		}
	}




}
