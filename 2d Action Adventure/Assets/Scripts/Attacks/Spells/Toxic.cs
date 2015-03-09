using UnityEngine;
using System.Collections;

public class Toxic : Spell {

	private int comboCode;
	private bool discovered;
	private string name;

	public Toxic()
	{
		name = "Toxic";
		comboCode = 1;
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

		int stacks = enemy.GetComponent<BuffDebuffManager>().GetElementStacks()[2];
		BuffDebuffManager bdmanager = enemy.GetComponent<BuffDebuffManager> ();
		bdmanager.RemoveBuffDeBuff("ToxicDebuff");
		bdmanager.AddBuffDebuff (new ToxicDebuff (stacks));

	}
	public string GetName ()
	{
		return name;
	}

}
