using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour 
{
	public void SpawnMeteors(int meteors,GameObject enemy)
	{
		float xRand;
		float timeToWait;
		
		for(int i = 0; i < meteors;i++)
		{
			xRand = Random.Range(-30f,10f);
			timeToWait = Random.Range (0f,4f);
			StartCoroutine (SpawnMeteor (xRand,timeToWait,enemy));
		}
	}

	
	IEnumerator SpawnMeteor(float xRand,float timeToWait,GameObject enemy)
	{
		yield return new WaitForSeconds (timeToWait);
		GameObject.Instantiate(Resources.Load<GameObject> ("Prefabs/Spells/Meteor"),enemy.transform.position + new Vector3(xRand,15,0),enemy.transform.rotation);		
	}


}
