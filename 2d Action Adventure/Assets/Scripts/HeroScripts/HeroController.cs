using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour 
{
	private Stats stats;
	private bool blinking = false;
	private bool grounded = false;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private float groundRadius = 0.2f;

	private bool doubleJump = false;
	private bool facingRight = true;

	private Animator anim;

	void Start() 
	{
		stats = GetComponent<Stats> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		UpdateGrounded ();
	}

	public bool isBlinking()
	{
		return blinking;
	}

	public void Jump ()
	{
		if ((grounded || !doubleJump))
		{		
			Vector2 v = rigidbody2D.velocity;
			v.y = 0;
			rigidbody2D.velocity = v;
			rigidbody2D.AddForce (new Vector2 (0, stats.jumpForce));
			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}
//	TODO
	public void BlinkRight ()
	{
//		if (stats.GetBlinkCounter() > 0 )
//		{
//			rigidbody2D.gravityScale = 0;
//			rigidbody2D.velocity = new Vector2 (0, 0);
//			rigidbody2D.AddForce (new Vector2 (stats.blinkSpeed, 0));
//			StartCoroutine (StartBlink ());
//			stats.SetBlinkCounter (stats.GetBlinkCounter () - 1);
//		}
	}
//
	public void BlinkLeft ()
	{
//		if (stats.GetBlinkCounter() > 0 )
//		{
//			rigidbody2D.gravityScale = 0;
//			rigidbody2D.velocity = new Vector2 (0, 0);
//			rigidbody2D.AddForce (new Vector2 (-stats.blinkSpeed, 0));
//			StartCoroutine (StartBlink ());
//			stats.SetBlinkCounter (stats.GetBlinkCounter () - 1);
//		}
	}
//	
//	IEnumerator StartBlink()
//	{
//		blinking = true;
//		yield return new WaitForSeconds (0.5f);
//		rigidbody2D.gravityScale = 5;
//		blinking = false;
//	}

	void UpdateGrounded ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (grounded)
			doubleJump = false;
	}

	public void MoveHero(float move)
	{
		anim.SetFloat("Speed",Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * stats.GetCurrentMovementSpeed(), rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
