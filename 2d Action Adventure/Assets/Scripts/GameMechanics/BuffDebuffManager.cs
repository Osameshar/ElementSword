using UnityEngine;
using System.Collections;

public class BuffDebuffManager : MonoBehaviour 
{
	private int[] elementStacks;
	private ArrayList currentBuffDebuffs;
	private ArrayList toRemoveBuffDebuffs;
	private const int MAX_STACKS = 5;
	public Stats stats;
	private GameObject guiManager;

	void Start () 
	{
		guiManager = GameObject.Find ("Gui Manager");
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
					removeBuffImage(bd);
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

		switch(bd.GetName())
		{
			case "QuickFireDebuff":
			{
				if(elementStacks[0] < MAX_STACKS)
				{
					currentBuffDebuffs.Add (bd);
					elementStacks[0]++;
					bd.onApply(stats);
				}
				break;
			}
			case "QuickFrostDebuff":
			{
				if(elementStacks[1] < MAX_STACKS)
					{
						currentBuffDebuffs.Add (bd);
						elementStacks[1]++;
						bd.onApply(stats);					
					}
				break;
			}
			case "QuickPoisonDebuff":
			{
				if(elementStacks[2] < MAX_STACKS)
					{
						currentBuffDebuffs.Add (bd);
						elementStacks[2]++;
						bd.onApply(stats);						
					}
				break;
			}
			case "QuickWindBuff":
			{
				if(elementStacks[3] < MAX_STACKS)
				{
					currentBuffDebuffs.Add (bd);
					elementStacks[3]++;
					bd.onApply(stats);
				}
				break;	
			}
			default:
				RemoveBuffDeBuff(bd.GetName());
				currentBuffDebuffs.Add (bd);
				bd.onApply(stats);
				addBuffImage(bd);
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
			bd.onEnd(stats);
			removeBuffImage(bd);
			currentBuffDebuffs.Remove (bd);
		}
		duplicate.Clear ();
	}

	void addBuffImage (BuffDebuff bd)
	{
		guiManager.GetComponent<StackNumbers> ().addBuffDebuff (bd);
	}
	void removeBuffImage(BuffDebuff bd)
	{
		guiManager.GetComponent<StackNumbers> ().removeBuffDebuff (bd);
	}
}
