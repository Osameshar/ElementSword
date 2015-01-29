using UnityEngine;
using System.Collections;

public class QuickFire : Attack,DefaultAttack
{
	private BuffDebuffLibrary lib;
	private float damage;
	private string nextAttack;
	private string previousAttack;
	private BuffDebuff debuff;


	public QuickFire()
	{
		GameObject libs = GameObject.FindWithTag ("Libraries");
		lib = libs.GetComponent<BuffDebuffLibrary> ();

		nextAttack = "QuickFrost";
		previousAttack = "QuickWind";
		damage = 10;
		debuff = lib.GetBuffDebuffByName ("QuickFireDebuff");

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
