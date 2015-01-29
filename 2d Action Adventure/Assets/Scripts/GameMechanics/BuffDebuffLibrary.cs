using UnityEngine;
using System.Collections;

public class BuffDebuffLibrary : MonoBehaviour 
{

	private Hashtable allBuffDebuffs;

	void Start()
	{
		allBuffDebuffs = new Hashtable();
		allBuffDebuffs.Add ("QuickFireDebuff", new QuickFireDebuff ());
		allBuffDebuffs.Add ("QuickFrostDebuff", new QuickFrostDebuff ());
		allBuffDebuffs.Add ("QuickPoisonDebuff", new QuickPoisonDebuff ());
		allBuffDebuffs.Add ("QuickWindBuff", new QuickWindBuff ());
	}

	public BuffDebuff GetBuffDebuffByName(string name)
	{
		return (BuffDebuff) allBuffDebuffs [name];
	}
}
