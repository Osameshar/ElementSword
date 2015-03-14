using UnityEngine;
using System.Collections;

public class DistortionWaveController : MonoBehaviour {

	private float damage;
	private float knockback;
	private GameObject gui;
	private EnemyHealthBar bar;
	private GameObject player;

	void Start()
	{
		gui = GameObject.FindGameObjectWithTag ("GUIManager");
		bar = gui.GetComponent<EnemyHealthBar> ();
	}

	public void setRadius(float radius)
	{
		GetComponent<CircleCollider2D> ().radius = radius;
	}
	public void setDamage (int tempDamage)
	{
		damage = tempDamage;
	}
	public void setKnockback(float tempKnockback)
	{
		knockback = tempKnockback;
	}
	public void setVelocity()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		if(player.GetComponent<HeroController>().facingRight == true)
		{
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (30, 0);
		}
		else
		{
			gameObject.transform.localScale = new Vector3(-1,1,1);
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-30, 0);
		}
	}
	public void startTimer()
	{
		StartCoroutine ("attackTimer");
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{	
			other.gameObject.GetComponent<CombatManagerEnemy>().TakeDamage(damage,null,true);

//			other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.transform.right * knockback,ForceMode2D.Impulse);
//			other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
//			other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			bar.updateGameObject(other.gameObject);
		}
	}
	IEnumerator attackTimer()
	{
		yield return new WaitForSeconds (2f);
		Destroy (this.gameObject);	
	}
}
