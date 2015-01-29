using UnityEngine;
using System.Collections;

public class QuickWind : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private BuffDebuff buff;

	public QuickWind()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();
		
		nextAttack = "QuickFire";
		previousAttack = "QuickPoison";
		damage = 10;
		buff = lib.GetBuffDebuffByName ("QuickWindBuff");
		
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
