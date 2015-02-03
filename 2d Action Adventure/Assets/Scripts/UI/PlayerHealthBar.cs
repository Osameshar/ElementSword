using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
	
	private GameObject player;
	private Stats stats;
	private Slider s;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		stats = player.GetComponent<Stats> ();
		s = GameObject.FindGameObjectWithTag ("PlayerFrame").GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		s.value = stats.health;
	}
}
