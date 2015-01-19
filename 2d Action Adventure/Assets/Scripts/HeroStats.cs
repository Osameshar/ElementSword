using UnityEngine;
using System.Collections;

public class HeroStats : MonoBehaviour {

	private int boostCounter = 3;
	private const int maxBoost = 3;
	private float nextBoost = 0.0f;

	public float boostRecharge = 10f;
	public float jumpForce = 700f;
	public float boostForce = 1.0f;
	public float attackSpeed = 1.0f;
	public float baseSpeed = 10f;
	public int damage = 10;
	public int health = 100;
	public int elementType = 0;
	public int attackType = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextBoost && boostCounter < maxBoost) 
		{
			nextBoost = Time.time + boostRecharge;
		}
	}

	public int GetBoostCounter()
	{
		return boostCounter;
	}
}
