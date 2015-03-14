using UnityEngine;
using System.Collections;

public class MeteorShower : Spell {

	private int comboCode;
	private bool discovered;
	private string name;
	public GameObject meteorPrefab;

	// Use this for initialization
	public MeteorShower()
	{
		name = "MeteorShower";
		comboCode = 100;
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
		int meteors = enemy.GetComponent<BuffDebuffManager> ().GetElementStacks () [0];
		meteors *= 4;//stacks*4 amount of meteors

		player.gameObject.GetComponent<MeteorSpawner> ().SpawnMeteors(meteors,enemy);


	}
	public string GetName ()
	{
		return name;
	}
	
}
