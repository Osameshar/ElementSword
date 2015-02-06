using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
	
	private GameObject player;
	private Stats stats;
	private Slider playerSlider;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		stats = player.GetComponent<Stats> ();
		playerSlider = GameObject.Find("PlayerPanel").GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		playerSlider.value = stats.health;
	}
}
