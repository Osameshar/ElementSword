using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	private HeroController controller;
	void Start () 
	{
		GameObject hc = GameObject.FindGameObjectWithTag ("Player");
		controller = hc.GetComponent<HeroController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!controller.isBlinking())
		{
			CheckForAttackInput ();
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
			controller.CycleElementForward ();
			
		}
		if (Input.GetButtonDown ("Cycle Backward"))
		{
			controller.CycleElementBackward ();
		}
	}

	void CheckForAttackInput()
	{
		//may need multiple depending on what axis is held down
		if(controller.CanAttack())
		{
			if(IsQuickAttack())
			{
				if (IsDownAttack ()) 
				{
					controller.SpawnBottomHitBox ();
				}
				else if (IsUpAttack()) 
				{
					controller.SpawnTopHitBox ();
				}
				else
				{
					controller.SpawnFrontHitBox ();
				}
				
			}
			else if(IsStrongAttack())
			{
				if (IsDownAttack ())
				{
					controller.SpawnStrongBottomHitBox();
				}
				else if( IsUpAttack())
				{
					controller.SpawnStrongTopHitBox ();
				}
				else
				{
					controller.SpawnStrongFrontHitBox();
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
