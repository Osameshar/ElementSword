using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour 
{
	bool facingRight;
	float xVRand;
	GameObject clone;

	public void SpawnMeteors(int meteors,GameObject enemy)
	{
		float xRand;
		float timeToWait;
		for(int i = 0; i < meteors;i++)
		{
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			facingRight = player.GetComponent<HeroController>().facingRight;
			if(facingRight)
			{
				xRand = Random.Range(-50f,0f);
			}
			else
			{
				xRand = Random.Range(0f,50f);
			}
			timeToWait = Random.Range (0f,4f);
			StartCoroutine (SpawnMeteor (xRand,timeToWait,enemy));

		}
	}

	
	IEnumerator SpawnMeteor(float xRand,float timeToWait,GameObject enemy)
	{
		yield return new WaitForSeconds (timeToWait);
		clone = (GameObject)GameObject.Instantiate(Resources.Load<GameObject> ("Prefabs/Spells/Meteor"),enemy.transform.position + new Vector3(xRand,8,0),enemy.transform.rotation);
		if(facingRight)
		{
			xVRand = Random.Range (20f, 50f);
		}
		else
		{
			clone.transform.localScale = new Vector3(-1,1,1);
			xVRand = Random.Range (-50f, -20f);
		}
		clone.GetComponent<MeteorController> ().setVelocity (xVRand);
	}


}
