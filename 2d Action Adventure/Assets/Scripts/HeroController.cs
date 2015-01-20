using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour 
{
	public GameObject forwardATK;
	public GameObject bottomATK;
	public GameObject topATK;

	private HeroStats stats;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	bool doubleJump = false;
	bool facingRight = true;

	void Start() 
	{
		stats = (HeroStats) GetComponent(typeof(HeroStats));
	}

	void Update()
	{
		CheckForAttackInput ();
		CheckForBoostInput ();
		CheckForSwitch ();
		CanDoubleJump ();
		UpdateMovement();
	}

	void FixedUpdate() 
	{
		//UpdateMovement();
	}

	void CheckForSwitch ()
	{
		if(Input.GetButtonDown ("Cycle Forward"))
		{
			if(stats.elementType != 3)
				stats.elementType++;
			else if(stats.elementType == 3)
				stats.elementType = 0;

		}
		if (Input.GetButtonDown ("Cycle Backward"))
		{
			if(stats.elementType != 0)
				stats.elementType--;
			else if(stats.elementType == 0)
				stats.elementType = 3;
		}
	}

	void CanDoubleJump ()
	{
		if ((grounded || !doubleJump) && Input.GetButtonDown ("Jump")) {
			rigidbody2D.AddForce (new Vector2 (0, stats.jumpForce));
			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void CheckForBoostInput ()
	{
		if (Input.GetButtonDown ("Boost") && stats.GetBoostCounter() > 0 )
		{

			Vector2 currentDirection = new Vector2(Input.GetAxis ("Horizontal") , Input.GetAxis ("Vertical"));
			rigidbody2D.AddForce(currentDirection * stats.boostForce);
			stats.SetBoostCounter(stats.GetBoostCounter() - 1);
		}
	}

	void CheckForAttackInput()
	{
		//may need multiple depending on what axis is held down
		if(IsQuickAttack())
		{
		   if (IsDownAttack ()) 
			{
				SpawnBottomHitBox ();
			}
			else if (IsUpAttack()) 
			{
				SpawnTopHitBox ();
			}
			else
			{
				SpawnFrontHitBox ();
			}
		}

	}

	void UpdateMovement()
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * stats.baseSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (grounded)
			doubleJump = false;
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator HitBoxLifeTime(GameObject hitBox)
	{
		yield return new WaitForFixedUpdate ();
		hitBox.collider2D.enabled = false;
		hitBox.GetComponent<SpriteRenderer>().enabled = false;

	}

	void SpawnFrontHitBox ()
	{
		stats.SetNextAttack(Time.time + stats.attackSpeed);
		forwardATK.collider2D.enabled = true;
		forwardATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (forwardATK));
	}

	void SpawnTopHitBox ()
	{
		stats.SetNextAttack(Time.time + stats.attackSpeed);
		topATK.collider2D.enabled = true;
		topATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (topATK));
	}

	void SpawnBottomHitBox ()
	{
		stats.SetNextAttack(Time.time + stats.attackSpeed);
		bottomATK.collider2D.enabled = true;
		bottomATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (bottomATK));
	}

	bool IsQuickAttack()
	{
		if (Input.GetButton ("Quick Attack") && Time.time > stats.GetNextAttack()) 
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
