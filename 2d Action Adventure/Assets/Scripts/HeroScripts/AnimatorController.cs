﻿using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour 
{
	private Animator forwardAnim;

	public GameObject personalAnimGO;
	private Animator personalAnim;

	private Animator playerAnim;
	// Use this for initialization
	void Start () 
	{
		playerAnim = GetComponent<Animator> ();
		personalAnim = personalAnimGO.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetForwardAttacking ()
	{
		forwardAnim.SetTrigger ("Attacking");
	}

	public void SetMainAttacking ()
	{
		playerAnim.SetTrigger ("Attacking");
	}
	
	public void UpdateActiveElementVariables (Attack currentAttack)
	{
		if (currentAttack.GetName ().Equals ("QuickFire")) 
		{
			forwardAnim.SetBool("FireEquipped",true);
			forwardAnim.SetBool("FrostEquipped",false);
			forwardAnim.SetBool("PoisonEquipped",false);
			forwardAnim.SetBool("WindEquipped",false);

		} 
		else if (currentAttack.GetName ().Equals ("QuickFrost")) 
		{
			forwardAnim.SetBool("FireEquipped",false);
			forwardAnim.SetBool("FrostEquipped",true);
			forwardAnim.SetBool("PoisonEquipped",false);
			forwardAnim.SetBool("WindEquipped",false);

		}
		else if (currentAttack.GetName ().Equals ("QuickPoison")) 
		{
			forwardAnim.SetBool("FireEquipped",false);
			forwardAnim.SetBool("FrostEquipped",false);
			forwardAnim.SetBool("PoisonEquipped",true);
			forwardAnim.SetBool("WindEquipped",false);

		}
		else if (currentAttack.GetName ().Equals ("QuickWind")) 
		{
			forwardAnim.SetBool("FireEquipped",false);
			forwardAnim.SetBool("FrostEquipped",false);
			forwardAnim.SetBool("PoisonEquipped",false);
			forwardAnim.SetBool("WindEquipped",true);

		}
	}
	public void SetStrong()
	{
		forwardAnim.SetTrigger ("Strong");
	}
	public void FrostShieldAnimation(bool val)
	{
		personalAnim.SetBool ("FrostShield",val);
	}
}
