using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
	
	public float jumpForce = 1000f;
	public float attackSpeed = 1.0f;
	public float baseSpeed = 10f;
	public float damage = 10f;
	public float health = 100f;
	public float shield = 0f;
	public float toughness = 1f;
	public float movementModifier = 1f;

	public float GetCurrentMovementSpeed()
	{
		return baseSpeed * movementModifier;
	}
}
