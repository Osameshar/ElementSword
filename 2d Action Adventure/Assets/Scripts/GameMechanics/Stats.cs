using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

	public float baseHealth = 100f;
	public float baseSpeed  = 10f;
	public float baseAttackSpeed = 1.0f;
	public float baseDamage = 10f;
	public float jumpForce = 1000f;

	private float attackSpeed;
	private float speed;
	private float damage;
	private float health;
	private float shield = 0f;
	private float toughness = 1f;
	private float movementModifier = 1f;

	void Start()
	{
		attackSpeed = baseAttackSpeed;
		speed = baseSpeed;
		damage = baseDamage;
		health = baseHealth;

	}
	public float GetCurrentMovementSpeed()
	{
		return baseSpeed * movementModifier;
	}
	public float getAttackSpeed()
	{
		return attackSpeed;
	}
	public float getDamage()
	{
		return damage;
	}
	public float getToughness()
	{
		return toughness;
	}
	public float getSpeed()
	{
		return speed;
	}
	public float getHealth()
	{
		return health;
	}
	public float getShield()
	{
		return shield;
	}
	public float getMovementModifier()
	{
		return movementModifier;
	}
	public void alterMovementModifier (float modifier)
	{
		movementModifier += modifier;
	}
	public void alterToughness (float modifier)
	{
		toughness += modifier;
	}
	public void alterShield(float shieldDamage)
	{
		shield -= shieldDamage;
	}
	public void alterHealth(float damage)
	{
		health -= damage;
	}
}
