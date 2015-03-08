using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour 
{

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

	public void SetMainAttacking ()
	{
		playerAnim.SetTrigger ("Attacking");
	}

	public void FrostShieldAnimation(bool val)
	{
		personalAnim.SetBool ("FrostShield",val);
	}

	public void ToxicAnimation(bool val)
	{
		personalAnim.SetBool ("Toxic",val);
	}
}
