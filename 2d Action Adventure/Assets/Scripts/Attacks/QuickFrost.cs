using UnityEngine;
using System.Collections;

public class QuickFrost : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private BuffDebuff debuff;

	
	public QuickFrost()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();
		
		nextAttack = "QuickPoison";
		previousAttack = "QuickFire";
		damage = 10;
		debuff = lib.GetBuffDebuffByName ("QuickFrostDebuff");
		
	}

	public void ExecuteAttack(GameObject enemy, GameObject player)
	{
		//TODO
	}
	
	public string GetNextAttack()
	{
		return nextAttack;
	}
	
	public string GetPreviousAttack()
	{
		return previousAttack;
	}
}
