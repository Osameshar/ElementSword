using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public int health = 100;
	public float attackSpeed = 1f;
	public float moveSpeed = 10f;
	public float jumpForce = 800f;
	public int damage = 10;
	public int maxStacks = 5;

	public int[] stacks = new int[3] {0,0,0}; //fire, frost, poison 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void takeDamage(int heroDamage, int elementType, int attackType)
	{
		health -= heroDamage; 
		if (health <= 0) 
		{
			Destroy(transform.gameObject);
			//death
		}
		if(elementType < 3 && attackType == 1 && stacks[elementType] < maxStacks)
	    {
    		stacks [elementType] ++; 
		}
		else if(elementType == 3 && attackType == 1)
		{
			//increase hero attack speed
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
}
