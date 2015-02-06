using UnityEngine;
using System.Collections;


public class CombatManager : MonoBehaviour 
{

	private Stats stats;
	private float nextAttack = 0.0f;

	public GameObject forwardATK;
	public GameObject bottomATK;
	public GameObject topATK;
	public GameObject strongForwardATK;
	public GameObject strongBottomATK;
	public GameObject strongTopATK;

	public Transform projSpawn;
	public GameObject projectileRight;
	public GameObject projectileLeft;

	private bool invulnerable = false;
	public float timeBetweenDamage = 1f;
	private Attack currentAttack;
	private Attack strongAttack;
	private AttackLibrary attackLibrary;
	private BuffDebuffManager bdManager;
	private SpellBook equippedSpells;

	private Animator anim;

	private Animator  forwardAnim;
	// Use this for initialization
	void Start () 
	{
		stats = GetComponent<Stats> ();
		GameObject libs = GameObject.FindWithTag ("Libraries");
		attackLibrary = libs.GetComponent<AttackLibrary>();

		anim = GetComponent<Animator> ();
		forwardAnim = GameObject.Find ("ForwardAnimation").GetComponent<Animator>();

		bdManager = GetComponent<BuffDebuffManager> ();

		equippedSpells = new SpellBook ();

		currentAttack = attackLibrary.GetAttackByName ("QuickFire");
		strongAttack = attackLibrary.GetAttackByName ("StrongAttack");

		forwardATK.collider2D.enabled = false;
		bottomATK.collider2D.enabled = false;
		topATK.collider2D.enabled = false;
		strongForwardATK.collider2D.enabled = false;
		strongBottomATK.collider2D.enabled = false;
		strongTopATK.collider2D.enabled = false;
	}

	public SpellBook GetEquippedSpells ()
	{
		return equippedSpells;
	}

	public Attack GetCurrentAttack()
	{
		return currentAttack;
	}
	public Attack GetStrongAttack()
	{
		return strongAttack;
	}
	public void CycleElementForward ()
	{
		currentAttack = attackLibrary.GetAttackByName(((DefaultAttack)currentAttack).GetNextAttack());
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
		GameObject.FindGameObjectWithTag ("GUIManager").GetComponent<ElementIcons> ().cycleIconsForward();
	}
	
	public void CycleElementBackward ()
	{
		currentAttack = attackLibrary.GetAttackByName(((DefaultAttack)currentAttack).GetPreviousAttack());
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
		GameObject.FindGameObjectWithTag ("GUIManager").GetComponent<ElementIcons> ().cycleIconsBackward();

	}

	IEnumerator HitBoxLifeTime(GameObject hitBox)
	{
		yield return new WaitForFixedUpdate ();
		hitBox.collider2D.enabled = false;
		//hitBox.GetComponent<SpriteRenderer>().enabled = false;
		nextAttack = (Time.time + stats.attackSpeed);
		
	}

	public void SpawnFrontHitBox ()
	{
		forwardATK.collider2D.enabled = true;
		anim.SetTrigger ("Attacking");
		forwardAnim.SetTrigger ("Attacking");
		//forwardATK.GetComponent<SpriteRenderer> ().enabled = true;
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
		strongForwardATK.collider2D.enabled = true;
		strongForwardATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (strongForwardATK));
	}

	public void SpawnStrongTopHitBox ()
	{
		strongTopATK.collider2D.enabled = true;
		strongTopATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (strongTopATK));		
	}

	public void SpawnStrongBottomHitBox ()
	{
		strongBottomATK.collider2D.enabled = true;
		strongBottomATK.GetComponent<SpriteRenderer> ().enabled = true;
		StartCoroutine (HitBoxLifeTime (strongBottomATK));
	}
	public void SpawnProjectileRight()
	{
		Instantiate (projectileRight, projSpawn.position,transform.rotation);
		nextAttack = (Time.time + stats.attackSpeed);
	}
	public void SpawnProjectileLeft()
	{
		Instantiate (projectileLeft, projSpawn.position,transform.rotation);
		nextAttack = (Time.time + stats.attackSpeed);
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

	public void TakeDamage(float damage, BuffDebuff bd)
	{
		if (invulnerable)
			return;
		damage = damage/stats.toughness;
		if(stats.shield < damage)
		{
			damage = damage - stats.shield;
			stats.health -= damage;
			stats.shield = 0f;
		}
		else
		{
			stats.shield -= damage;
		}

		if(bd != null)
			bdManager.AddBuffDebuff (bd);
		invulnerable = true;
		StartCoroutine (InvulnerableTime ());
	}
	IEnumerator InvulnerableTime()
	{
		yield return new WaitForSeconds(timeBetweenDamage);
		invulnerable = false;
	}
}
