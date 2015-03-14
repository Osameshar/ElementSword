using UnityEngine;
using System.Collections;

public class SteamField : Spell {

	private int comboCode;
	private bool discovered;
	private string name;
	
	public SteamField()
	{
		name = "SteamField";
		comboCode = 110;
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
		int fireStacks = bdmanager.GetElementStacks()[0];
		int frostStacks = bdmanager.GetElementStacks()[1];
		float radius = fireStacks + 2;
		int duration = 2 + (2 * frostStacks);
		Object clone;
		clone = GameObject.Instantiate(Resources.Load<GameObject> ("Prefabs/Spells/SteamField"),player.transform.position,player.transform.rotation);	
		((GameObject)clone).GetComponent<SteamFieldController> ().setRadius (radius);
		((GameObject)clone).GetComponent<SteamFieldController> ().setDuration (duration);
		((GameObject)clone).GetComponent<SteamFieldController> ().setStacks(fireStacks,frostStacks);
	}

	public string GetName ()
	{
		return name;
	}


}
