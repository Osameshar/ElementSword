using UnityEngine;
using System.Collections;

public class FrostShield : Spell {

	private int comboCode;
	private bool discovered;
	private string name;
	// Use this for initialization
	public FrostShield()
	{
		name = "FrostShield";
		comboCode = 10;
	}

	public string GetName()
	{
		return name;
	}
	public bool IsDiscovered ()
	{
		return discovered;
	}
	
	public int GetComboCode()
	{
		return comboCode;
	}

	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		int stacks = enemy.GetComponent<BuffDebuffManager>().GetElementStacks()[1];
		BuffDebuffManager bdmanager = player.GetComponent<BuffDebuffManager> ();
		bdmanager.RemoveBuffDeBuff("FrostShieldBuff");
		bdmanager.AddBuffDebuff (new FrostShieldBuff (stacks));
	}
}
