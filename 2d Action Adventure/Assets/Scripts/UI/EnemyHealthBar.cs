using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	private GameObject enemyFrame;
	private Stats stats;
	private Slider enemySlider;
	private bool activeFrame;
	// Use this for initialization
	void Start () {
		enemyFrame = GameObject.Find("EnemyPanel");
		activeFrame = false;
		enemyFrame.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if(activeFrame)
		{
			enemySlider.value = stats.getHealth();
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
			stats = go.GetComponent<Stats> ();
			enemySlider = enemyFrame.GetComponentInChildren<Slider>();
		}

	}
}
