using UnityEngine;
using System.Collections;

public class DistortionWave : Spell {

	private int comboCode;
	private bool discovered;
	private string name;
	public GameObject dWavePrefab;
	
	// Use this for initialization
	public DistortionWave()
	{
		name = "DistortionWave";
		comboCode = 111;
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
		int fireStacks = enemy.GetComponent<BuffDebuffManager> ().GetElementStacks () [0];
		int frostStacks = enemy.GetComponent<BuffDebuffManager> ().GetElementStacks () [1];
		int poisonStacks = enemy.GetComponent<BuffDebuffManager> ().GetElementStacks () [2];
		float radius = fireStacks * 3;
		int damage = 10 * poisonStacks;
		//float knockback = 10 * frostStacks;
		Object clone;
		clone = GameObject.Instantiate(Resources.Load<GameObject> ("Prefabs/Spells/DistortionWave"),player.transform.position,player.transform.rotation);	
		((GameObject)clone).GetComponent<DistortionWaveController> ().setRadius (radius);
		((GameObject)clone).GetComponent<DistortionWaveController> ().setDamage (damage);
		//((GameObject)clone).GetComponent<DistortionWaveController> ().setKnockback(knockback);
		((GameObject)clone).GetComponent<DistortionWaveController> ().setVelocity ();
		((GameObject)clone).GetComponent<DistortionWaveController> ().startTimer ();
	}
	public string GetName ()
	{
		return name;
	}
}
