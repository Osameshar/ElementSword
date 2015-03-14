using UnityEngine;
using System.Collections;

public class SteamFieldController : MonoBehaviour {

	private int remainingDuration;
	private int fireStacks;
	private int frostStacks;
	BuffDebuffManager bdmanager;
	
	public void setRadius(float radius)
	{
		GetComponent<CircleCollider2D> ().radius = radius;
	}
	public void setDuration (int duration)
	{
		StartCoroutine (SpawnField(duration));
	}
	public void setStacks(int currentFireStacks, int currentFrostStacks)
	{
		fireStacks = currentFireStacks;
		frostStacks = currentFrostStacks;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		bdmanager = GameObject.FindGameObjectWithTag("Player").GetComponent<BuffDebuffManager> ();
		if(other.tag == "Player")
		{	
			AddBuff();
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			AddBuff();
		}
	}
	IEnumerator SpawnField(int duration)
	{
		yield return new WaitForSeconds (duration);
		Destroy (this.gameObject);	
	}
	void AddBuff()
	{
			bdmanager.RemoveBuffDeBuff("SteamFieldBuff");
			bdmanager.AddBuffDebuff (new SteamFieldBuff (fireStacks,frostStacks));
	}
}
