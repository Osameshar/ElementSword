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

	private Attack currentAttack;
	private Attack strongAttack;
	private AttackLibrary attackLibrary;
	private SpellBook equippedSpells;
	// Use this for initialization
	void Start () 
	{
		stats = GetComponent<Stats> ();
		GameObject libs = GameObject.FindWithTag ("Libraries");
		attackLibrary = libs.GetComponent<AttackLibrary>();

		equippedSpells = new SpellBook ();

		currentAttack = attackLibrary.GetAttackByName ("QuickFire");
		strongAttack = attackLibrary.GetAttackByName ("StrongAttack");
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
	}
	
	public void CycleElementBackward ()
	{
		currentAttack = attackLibrary.GetAttackByName(((DefaultAttack)currentAttack).GetPreviousAttack());
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
