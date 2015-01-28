using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour 
{
	public GameObject forwardATK;
	public GameObject bottomATK;
	public GameObject topATK;
	public GameObject forwardStrongATK;
	public GameObject bottomStrongATK;
	public GameObject topStrongATK;

	private HeroStats stats;
	private bool blinking = false;
	private bool grounded = false;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private float groundRadius = 0.2f;

	private bool doubleJump = false;
	private bool facingRight = true;
	private float nextAttack = 0.0f;

	private Animator anim;

	void Start() 
	{
		stats = (HeroStats) GetComponent(typeof(HeroStats));
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

	public void CycleElementForward ()
	{
		if (stats.elementType != 3)
			stats.elementType++;
		else
			if (stats.elementType == 3)
				stats.elementType = 0;
	}

	public void CycleElementBackward ()
	{
		if (stats.elementType != 0)
			stats.elementType--;
		else
			if (stats.elementType == 0)
				stats.elementType = 3;
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

	public void BlinkRight ()
	{
		if (stats.GetBlinkCounter() > 0 )
		{
			rigidbody2D.gravityScale = 0;
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.AddForce (new Vector2 (stats.blinkSpeed, 0));
			StartCoroutine (StartBlink ());
			stats.SetBlinkCounter (stats.GetBlinkCounter () - 1);
		}
	}

	public void BlinkLeft ()
	{
		if (stats.GetBlinkCounter() > 0 )
		{
			rigidbody2D.gravityScale = 0;
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.AddForce (new Vector2 (-stats.blinkSpeed, 0));
			StartCoroutine (StartBlink ());
			stats.SetBlinkCounter (stats.GetBlinkCounter () - 1);
		}
	}
	
	IEnumerator StartBlink()
	{
		blinking = true;
		yield return new WaitForSeconds (0.5f);
		rigidbody2D.gravityScale = 5;
		blinking = false;
	}

	void UpdateGrounded ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		if (grounded)
			doubleJump = false;
	}

	public void MoveHero(float move)
	{
		anim.SetFloat("Speed",Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * stats.baseSpeed, rigidbody2D.velocity.y);
		
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

	IEnumerator HitBoxLifeTime(GameObject hitBox)
	{
		yield return new WaitForFixedUpdate ();
		hitBox.collider2D.enabled = false;
		hitBox.GetComponent<SpriteRenderer>().enabled = false;
		nextAttack = (Time.time + stats.attackSpeed);

	}

	public void SpawnFrontHitBox ()
	{
		forwardATK.collider2D.enabled = true;
		forwardATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (forwardATK));
	}

	public void SpawnTopHitBox ()
	{
		topATK.collider2D.enabled = true;
		topATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (topATK));
	}

	public void SpawnBottomHitBox ()
	{
		bottomATK.collider2D.enabled = true;
		bottomATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (bottomATK));
	}

	public void SpawnStrongFrontHitBox ()
	{
		forwardStrongATK.collider2D.enabled = true;
		forwardStrongATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (forwardStrongATK));
	}
	public void SpawnStrongTopHitBox ()
	{
		topStrongATK.collider2D.enabled = true;
		topStrongATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (topStrongATK));		
	}
	public void SpawnStrongBottomHitBox ()
	{
		bottomStrongATK.collider2D.enabled = true;
		bottomStrongATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (bottomStrongATK));
	}
	public bool CanAttack()
	{
		if(Time.time > nextAttack)
		{
			return true;
		}
		else
			return false;
	}
}
