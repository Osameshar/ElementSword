using UnityEngine;
using System.Collections;

public class QuickPoison : Attack,DefaultAttack 
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private BuffDebuff debuff;

	public QuickPoison()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();
		
		nextAttack = "QuickWind";
		previousAttack = "QuickFrost";
		damage = 10;
		debuff = lib.GetBuffDebuffByName ("QuickPoisonDebuff");
		
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
