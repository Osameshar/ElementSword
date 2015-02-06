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
		elementStacks = new int[4]{0,0,0,0};//FIRE,FROST,POISON,WIND
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
	public void ClearStacks()
	{
		elementStacks [0] = 0;
		elementStacks [1] = 0;
		elementStacks [2] = 0;
		RemoveBuffDeBuff ("QuickFireDebuff");
		RemoveBuffDeBuff ("QuickFrostDebuff");
		RemoveBuffDeBuff ("QuickPoisonDebuff");
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
				case "QuickWindBuff":
				{
					elementStacks[3]--;
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
			case "QuickWindBuff":
			{
				elementStacks[3]++;
				bd.onApply(stats);
				break;	
			}
			default:
				bd.onApply(stats);
				break;

		}
	}

	public void RemoveBuffDeBuff (string name)
	{
		ArrayList duplicate = new ArrayList ();
		foreach (BuffDebuff bd in currentBuffDebuffs) 
		{
			if(bd.GetName().Equals(name))
				duplicate.Add(bd);
		}
		foreach (BuffDebuff bd in duplicate) 
		{
			currentBuffDebuffs.Remove (bd);
		}
		duplicate.Clear ();
	}
}
