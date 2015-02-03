using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{

	// Use this for initialization
	private HeroController controller;
	private CombatManager combat;
	void Start () 
	{
		GameObject hc = GameObject.FindGameObjectWithTag ("Player");
		controller = hc.GetComponent<HeroController>();
		combat = hc.GetComponent<CombatManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!controller.isBlinking())
		{
			CheckForAttackInput ();
			CheckForProjectileInput();
			CheckForBlinkInput ();
			CheckForElementSwitchInput ();
			CheckJumpInput ();
			CheckHorizontalInput();

		}
	}

	void CheckHorizontalInput ()
	{
		float move = Input.GetAxis ("Horizontal");
		controller.MoveHero (move);
	}

	void CheckJumpInput ()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			controller.Jump();
		}

	}

	void CheckForBlinkInput ()
	{
		if (Input.GetAxis("RightBlink") > 0)
		{
			controller.BlinkRight ();
		}
		if(Input.GetAxis("LeftBlink") > 0)
		{
			controller.BlinkLeft ();
		}
	}

	void CheckForElementSwitchInput ()
	{
		if(Input.GetButtonDown ("Cycle Forward"))
		{
			combat.CycleElementForward ();
			
		}
		if (Input.GetButtonDown ("Cycle Backward"))
		{
			combat.CycleElementBackward ();
		}
	}

	void CheckForProjectileInput()
	{
		if (combat.CanAttack ())
		{
			if (Input.GetButtonDown ("Projectile Attack")) 
			{
				controller.SpawnProjectileAttack();
			}
		}
	}
	void CheckForAttackInput()
	{
		//may need multiple depending on what axis is held down
		if(combat.CanAttack())
		{
			if(IsQuickAttack())
			{
				if (IsDownAttack ()) 
				{
					combat.SpawnBottomHitBox ();
				}
				else if (IsUpAttack()) 
				{
					combat.SpawnTopHitBox ();
				}
				else
				{
					combat.SpawnFrontHitBox ();
				}
				
			}
			else if(IsStrongAttack())
			{
				if (IsDownAttack ())
				{
					combat.SpawnStrongBottomHitBox();
				}
				else if( IsUpAttack())
				{
					combat.SpawnStrongTopHitBox ();
				}
				else
				{
					combat.SpawnStrongFrontHitBox();
				}
				
			}
		}
	}
	
	bool IsQuickAttack()
	{
		if (Input.GetButton ("Quick Attack")) 
		{
			return true;
		} 
		else
			return false;
	}

	bool IsStrongAttack ()
	{
		if (Input.GetButton ("Strong Attack")) 
		{
			return true;
		}
		else
			return false;
	}

	bool IsUpAttack()
	{
		if ((Input.GetAxis ("Vertical") > 0.9f) && Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.2f )
		{
			return true;
		}
		else
			return false;
	}
	
	bool IsDownAttack()
	{
		if ((Input.GetAxis ("Vertical") < -0.9f) && Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.2f)
		{
			return true;		
		}
		else
			return false;
	}
}
