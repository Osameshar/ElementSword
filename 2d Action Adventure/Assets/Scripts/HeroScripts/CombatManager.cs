using UnityEngine;
using System.Collections;


public class CombatManager : MonoBehaviour 
{

	private Stats stats;
	private float nextAttack = 0.0f;

	public Transform forwardATKLoc;
	public Transform topATKLoc;
	public Transform botATKLoc;

	public GameObject quickAttackRight;
	public GameObject quickAttackLeft;
	public GameObject strongAttackRight;
	public GameObject strongAttackLeft;



	public Transform projSpawn;
	public GameObject projectileLeft;
	public GameObject projectileRight;

	private bool invulnerable = false;
	public float timeBetweenDamage = 1f;
	private Attack currentAttack;
	private Attack strongAttack;
	private AttackLibrary attackLibrary;
	private BuffDebuffManager bdManager;
	private SpellBook equippedSpells;

	private AnimatorController animatorController;
	// Use this for initialization
	void Start () 
	{
		stats = GetComponent<Stats> ();
		GameObject libs = GameObject.FindWithTag ("Libraries");
		attackLibrary = libs.GetComponent<AttackLibrary>();
		
		animatorController = GetComponent<AnimatorController> ();

		bdManager = GetComponent<BuffDebuffManager> ();

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
		GameObject.FindGameObjectWithTag ("GUIManager").GetComponent<ElementIcons> ().cycleIconsForward();
	}
	
	public void CycleElementBackward ()
	{
		currentAttack = attackLibrary.GetAttackByName(((DefaultAttack)currentAttack).GetPreviousAttack());
		GameObject.FindGameObjectWithTag ("GUIManager").GetComponent<ElementIcons> ().cycleIconsBackward();

	}

	public void SpawnForwardRight ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (quickAttackRight, forwardATKLoc.position, transform.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}
	public void SpawnForwardLeft ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (quickAttackLeft, forwardATKLoc.position, transform.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}

	public void SpawnStrongForwardRight ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (strongAttackRight, forwardATKLoc.position, transform.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}

	public void SpawnTopHitBox ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (quickAttackRight,topATKLoc.position,topATKLoc.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}	
	
	public void SpawnBottomHitBox ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (quickAttackLeft,botATKLoc.position,botATKLoc.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}	

	public void SpawnStrongForwardLeft ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (strongAttackLeft, forwardATKLoc.position, transform.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}
	
	public void SpawnStrongTopHitBox ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (strongAttackRight, topATKLoc.position, topATKLoc.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}
	public void SpawnStrongBottomHitBox ()
	{
		animatorController.SetMainAttacking ();
		Instantiate (strongAttackLeft, botATKLoc.position, botATKLoc.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}
	public void SpawnProjectileRight()
	{
		animatorController.SetMainAttacking ();
		Instantiate (projectileRight, projSpawn.position,transform.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
	}
	public void SpawnProjectileLeft()
	{
		animatorController.SetMainAttacking ();
		Instantiate (projectileLeft, projSpawn.position,transform.rotation);
		nextAttack = (Time.time + stats.getAttackSpeed());
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

	public void TakeDamage(float damage, BuffDebuff bd, bool activatesInvuln)
	{
		if (invulnerable)
			return;
		damage = damage/stats.getToughness();
		if(stats.getShield() < damage)
		{
			damage = damage - stats.getShield();
			stats.alterHealth(damage);
			stats.alterShield(stats.getShield());
		}
		else
		{
			stats.alterShield(damage);
		}

		if(bd != null)
			bdManager.AddBuffDebuff (bd);
		if(activatesInvuln)
		{
			invulnerable = true;
			StartCoroutine (InvulnerableTime ());
		}
	}
	IEnumerator InvulnerableTime()
	{
		yield return new WaitForSeconds(timeBetweenDamage);
		invulnerable = false;
	}
}
