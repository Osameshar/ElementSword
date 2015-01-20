using UnityEngine;
using System.Collections;

public class HeroStats : MonoBehaviour {

	private int boostCounter = 0;//change this
	private const int maxBoost = 3;
	private float nextBoost = 10f;
	private float currentWindStackDuration = 0f;
	private int windStacks = 0;
	private float nextAttack = 1f;

	public float boostRecharge = 10f;
	public float jumpForce = 700f;
	public float boostForce = 1000f;
	public float attackSpeed = 1.0f;
	public float baseSpeed = 10f;
	public int damage = 10;
	public int health = 100;
	public int elementType = 0;
	public int attackType = 1;
	public float windBuffAmount = .1f;
	public float windStackDuration = 10f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		CheckBoostRecharge ();
		CheckWindDuration ();
	}

	public int GetBoostCounter()
	{
		return boostCounter;
	}
	public int GetWindStacks()
	{
		return windStacks;
	}
	public float GetNextAttack()
	{
		return nextAttack;
	}

	public void SetBoostCounter (int newBoostCounter)
	{
		boostCounter = newBoostCounter;
	}

	public void SetNextAttack (float newNextAttack)
	{
		nextAttack = newNextAttack;
	}

	void CheckBoostRecharge ()
	{
		if (Time.time > nextBoost && boostCounter < maxBoost) {
			nextBoost = Time.time + boostRecharge;
			boostCounter++;
			Debug.Log("up");
		}
	}

	void CheckWindDuration ()
	{
		if (Time.time > currentWindStackDuration && windStacks > 0) {
			currentWindStackDuration = Time.time + windStackDuration;
			RemoveWindStack ();
		}
	}

	public void AddWindStack ()
	{
		windStacks++;
		if(windStacks == 1)
		{
			currentWindStackDuration = Time.time + windStackDuration;
		}
		attackSpeed -= windBuffAmount;
	}
	public void RemoveWindStack()
	{
		windStacks--;
		attackSpeed += windBuffAmount;
	}
}
