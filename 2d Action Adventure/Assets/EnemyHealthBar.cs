using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	private GameObject enemyFrame;
	private GameObject enemy;
	private Stats stats;
	private Slider s;
	private bool activeFrame;
	// Use this for initialization
	void Start () {
		enemyFrame = GameObject.FindGameObjectWithTag ("EnemyFrame");
		activeFrame = false;
		enemyFrame.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if(activeFrame)
		{
			s.value = stats.health;
		}
	}

	public void updateGameObject(GameObject go)
	{
		if(activeFrame == false)
		{
			activeFrame = true;
			enemyFrame.SetActive(true);

		}
		if(activeFrame == true)
		{
			enemy = go;
			stats = enemy.GetComponent<Stats> ();
			s = enemyFrame.GetComponentInChildren<Slider>();
		}

	}
}
