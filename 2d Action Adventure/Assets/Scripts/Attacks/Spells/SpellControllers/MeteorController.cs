using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour {

	private GameObject gui;
	private EnemyHealthBar bar;
	private float damage;
	private CircleCollider2D circleCollider;
	private CircleCollider2D trigger;
	// Use this for initialization
	void Start () 
	{	
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
		damage = 20;
		circleCollider = new CircleCollider2D ();
		trigger = new CircleCollider2D ();
		circleCollider = gameObject.AddComponent<CircleCollider2D>();
		trigger = gameObject.AddComponent<CircleCollider2D> ();
		trigger.isTrigger = true;
		circleCollider.radius = 0.7f;
		trigger.radius = 1f;
		float xVRand = Random.Range (0f, 30f);
		float yVRand = Random.Range (-4f, 0f);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (xVRand, yVRand);

		StartCoroutine (HitBoxLifeTime ());
	}

	IEnumerator HitBoxLifeTime()
	{
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);
		
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<CombatManagerEnemy>().TakeDamage(damage,null,true);
			bar.updateGameObject(other.gameObject);
			Destroy(this.gameObject);

		}

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Physics2D.IgnoreCollision(circleCollider,other.collider);
		}
	}
}
