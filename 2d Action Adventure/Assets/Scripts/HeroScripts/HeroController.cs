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

		transform.position = new Vector3 (transform.position.x + 5, transform.position.y, 0);

	}

	public void BlinkLeft ()
	{
		//transform.Translate (new Vector3 (transform.position.x - 1, transform.position.y -1, 0));
		transform.position = new Vector3 (transform.position.x - 5, transform.position.y, 0);

	}
	
//	IEnumerator StartBlink()
//	{
//		blinking = true;
//		yield return new WaitForSeconds (2f);
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
