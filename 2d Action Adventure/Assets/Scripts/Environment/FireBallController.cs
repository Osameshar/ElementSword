using UnityEngine;
using System.Collections;

public class FireBallController : MonoBehaviour 
{
	private GameObject player;
	private GameObject gui;
	private EnemyHealthBar bar;
	private Animator projectileAnim;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		projectileAnim = GetComponent<Animator> ();
		projectileAnim.SetBool("FireEquipped",true);
		StartCoroutine (ProjLifeTime ());
	}

	IEnumerator ProjLifeTime()
	{
		yield return new WaitForSeconds (3f);
		Destroy (this.gameObject);		
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			player.GetComponent<Stats>().alterHealth(10f);
		}
		else if(other.tag != "Enemy")
		{
			Destroy(this.gameObject);
		}
	}
}
