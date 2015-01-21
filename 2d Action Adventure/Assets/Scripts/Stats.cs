using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	private HeroStats heroStats;
	private float currentFireStackDuration = 0f;
	private float fireStackDuration = 10f;
	private float currentPoisonStackDuration = 0f;
	private float currentPoisonDamageTicker = 1f;
	private float poisonDamageTicker = 1f;
	private float poisonStackDuration = 10f;
	private float currentFrostStackDuration = 0f;
	private float frostStackDuration = 10f;
	private float nextSecond = 0f;

	public int health = 100;
	public float attackSpeed = 1f;
	public float moveSpeed = 10f;
	public float jumpForce = 800f;
	public int damage = 10;
	public int maxStacks = 5;
	public int poisonDamage = 1;
	public float frostEffectMovement = 1f;
	public float frostEffectAttack = .1f;
	public int fireMultiplier = 2;

	public int[] stacks = new int[3] {0,0,0}; //fire, frost, poison 
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("Hero");
		heroStats = (HeroStats) go.GetComponent(typeof(HeroStats));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > nextSecond)
		{
			nextSecond = Time.time + 1f;
			CheckFireDuration ();
			CheckPoisonDamage ();
			CheckPoisonDuration ();
			CheckFrostDuration ();
		}

		CheckDeath ();
	}
	
	public void takeDamage(int heroDamage, int elementType, int attackType)
	{
		health -= heroDamage + (stacks [0] * fireMultiplier);
		CheckDeath ();
		if(elementType < 3 && attackType == 1 && stacks[elementType] < maxStacks)
	    {
    		stacks [elementType] ++;
			switch(elementType)
			{
				case 0:
					fireEffect();
					break;

				case 1:
					frostEffect();
					break;

				case 2:
					poisonEffect();
					break;
			}
		}
		else if(elementType == 3 && attackType == 1 && heroStats.GetWindStacks() < maxStacks)
		{
			heroStats.AddWindStack();
		}
		else if (attackType == 2)
		{

			switch(elementType)
			{
				case 0:
					//effect of fire
					break;
				case 1:
					//effect of frost
					break;
				case 2:
					//effect of poison
					break;
				case 3:
					//effect of wind
					break;				
			}

		}
	}

	void CheckDeath ()
	{
		if (health <= 0) 
		{
			Destroy(transform.gameObject);
		}
	}

	void CheckFireDuration ()
	{
		if (Time.time > currentFireStackDuration && stacks[0] > 0) {
			currentFireStackDuration = Time.time + fireStackDuration;
			stacks[0]--;
		}
	}

	void CheckPoisonDamage ()
	{
		if (Time.time > currentPoisonDamageTicker && stacks[2] > 0) {
			currentPoisonDamageTicker = Time.time + poisonDamageTicker;
			health -= poisonDamage * stacks[2];
		}
	}

	void CheckPoisonDuration ()
	{
		if (Time.time > currentPoisonStackDuration && stacks[2] > 0) {
			currentPoisonStackDuration = Time.time + poisonStackDuration;
			stacks[2]--;
		}
	}

	void CheckFrostDuration ()
	{
		if (Time.time > currentFrostStackDuration && stacks[1] > 0) {
			currentFrostStackDuration = Time.time + frostStackDuration;
			RemoveFrostStack ();
		}
	}

	void poisonEffect ()
	{
		if(stacks[2] == 1)
		{
			currentPoisonStackDuration = Time.time + poisonStackDuration;
		}
	}
	void fireEffect ()
	{
		if(stacks[0] == 1)
		{
			currentFireStackDuration = Time.time + fireStackDuration;
		}
	}
	void frostEffect ()
	{
		if(stacks[1] == 1)
		{
			currentFrostStackDuration = Time.time + frostStackDuration;
		}
		moveSpeed -= frostEffectMovement;
		attackSpeed += frostEffectAttack;
	}

	void RemoveFrostStack ()
	{
		stacks [1]--;
		moveSpeed += frostEffectMovement;
		attackSpeed -= frostEffectAttack;
	}
}
