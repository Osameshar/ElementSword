using UnityEngine;
using System.Collections;

public class Pitfall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
		{
			other.GetComponent<Stats>().setHealth(0f);
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
		}
	}
}
