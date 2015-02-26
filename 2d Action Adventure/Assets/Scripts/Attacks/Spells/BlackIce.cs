using UnityEngine;
using System.Collections;

public class BlackIce : Spell {
		
	private int comboCode;
	private bool discovered;
	private string name;



	public BlackIce()
	{
		name = "BlackIce";
		comboCode = 11;
	}

	public bool IsDiscovered ()
	{
		return discovered;
	}
	public int GetComboCode ()
	{
		return comboCode;
	}

	public void ExecuteAttack (GameObject enemy, GameObject player)
	{
		BuffDebuffManager bdmanager = enemy.GetComponent<BuffDebuffManager> ();
		int coldStacks = bdmanager.GetElementStacks()[1];
		int poisonStacks = bdmanager.GetElementStacks()[2];
		bdmanager.RemoveBuffDeBuff("BlackIceDebuff");
		bdmanager.AddBuffDebuff (new BlackIceDebuff (coldStacks,poisonStacks));
	}
	public string GetName ()
	{
		return name;
	}

}
