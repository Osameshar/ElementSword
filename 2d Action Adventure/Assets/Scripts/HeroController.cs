using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour 
{
	public GameObject forwardATK;
	public GameObject bottomATK;
	public GameObject topATK;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	bool doubleJump = false;
	
	public float baseSpeed = 10f;
	bool facingRight = true;

	public float attackSpeed = 1.0f;
	private float nextAttack = 0.0f;


	void Start() 
	{
	
	}

	void Update()
	{
		CheckForAttackInput();

		if ((grounded || !doubleJump) && Input.GetButtonDown ("Jump")) 
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			
			if(!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	void FixedUpdate() 
	{
		UpdateMovement();

	}

	void CheckForAttackInput()
	{
		//may need multiple depending on what axis is held down
		if ((Input.GetAxis("Vertical") < -0.9f) && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f && Input.GetButton ("Quick Attack") && Time.time > nextAttack) 
		{
			nextAttack = Time.time + attackSpeed;
			bottomATK.collider2D.enabled = true;
			bottomATK.GetComponent<SpriteRenderer>().enabled = true;
			StartCoroutine(HitBoxLifeTime(bottomATK));
		}
		else if ((Input.GetAxis("Vertical") > 0.9f) && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f && Input.GetButton ("Quick Attack") && Time.time > nextAttack) 
		{
			nextAttack = Time.time + attackSpeed;
			topATK.collider2D.enabled = true;
			topATK.GetComponent<SpriteRenderer>().enabled = true;
			StartCoroutine(HitBoxLifeTime(topATK));
		}
		else if(Input.GetButton ("Quick Attack") && Time.time > nextAttack)
		{
			nextAttack = Time.time + attackSpeed;
			forwardATK.collider2D.enabled = true;
			forwardATK.GetComponent<SpriteRenderer>().enabled = true;
			StartCoroutine(HitBoxLifeTime(forwardATK));
		}
	}
	IEnumerator HitBoxLifeTime(GameObject hitBox)
	{
		yield return new WaitForFixedUpdate ();
		hitBox.collider2D.enabled = false;
		hitBox.GetComponent<SpriteRenderer>().enabled = false;

	}
	void UpdateMovement()
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * baseSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		//TEMPORARY JUMPING
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

}
