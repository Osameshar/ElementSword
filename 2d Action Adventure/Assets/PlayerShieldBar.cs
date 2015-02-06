using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShieldBar : MonoBehaviour {

	private GameObject player;
	private GameObject playerFrame;
	private Stats stats;
	private Slider shieldSlider;
	private bool isInactive;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		stats = player.GetComponent<Stats> ();
		playerFrame = GameObject.Find ("PlayerShieldBar");
		shieldSlider = playerFrame.GetComponentInChildren<Slider>();
		isInactive = true;
	}
	
	// Update is called once per frame
	void Update () {
		shieldSlider.value = stats.shield;
		if(stats.shield > 0 && isInactive)
		{
			isInactive = false;
			playerFrame.SetActive(true);
		}
		if (stats.shield == 0)
		{
			isInactive = true;
			playerFrame.SetActive(false);
		}
	}
}
