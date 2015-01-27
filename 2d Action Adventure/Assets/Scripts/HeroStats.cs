using UnityEngine;
using System.Collections;

public class HeroStats : MonoBehaviour {

	private int blinkCounter = 3;//change this
	private const int maxBlink = 3;
	private float nextBlink = 10f;
	private float currentWindStackDuration = 0f;
	private int windStacks = 0;
	private float nextAttack = 1f;

	public float blinkRecharge = 10f;
	public float jumpForce = 1000f;
	public float blinkSpeed = 1000f;
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
		nextAttack = Time.time + attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		CheckBlinkRecharge ();
		CheckWindDuration ();
	}

	public int GetBlinkCounter()
	{
		return blinkCounter;
	}
	public int GetWindStacks()
	{
		return windStacks;
	}
	public float GetNextAttack()
	{
		return nextAttack;
	}

	public void SetBlinkCounter (int newBlinkCounter)
	{
		blinkCounter = newBlinkCounter;
	}

	public void SetNextAttack (float newNextAttack)
	{
		nextAttack = newNextAttack;
	}

	void CheckBlinkRecharge ()
	{
		if (Time.time > nextBlink && blinkCounter < maxBlink) {
			nextBlink = Time.time + blinkRecharge;
			blinkCounter++;
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
