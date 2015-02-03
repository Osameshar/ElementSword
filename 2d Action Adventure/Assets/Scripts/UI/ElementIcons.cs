using UnityEngine;
using System.Collections;

public class ElementIcons : MonoBehaviour {

	private GameObject fireIcon;
	private GameObject frostIcon;
	private GameObject poisonIcon;
	private GameObject windIcon;
	private int currentIcon;
	// Use this for initialization
	void Start () {
		fireIcon = GameObject.Find ("FireIcon");
		frostIcon = GameObject.Find ("FrostIcon");
		poisonIcon = GameObject.Find ("PoisonIcon");
		windIcon = GameObject.Find ("WindIcon");

		currentIcon = 0;

		fireIcon.SetActive (true);
		frostIcon.SetActive (false);
		poisonIcon.SetActive (false);
		windIcon.SetActive(false);
	}
	
	public void cycleIconsForward()
	{
		if(currentIcon == 3)
		{
			currentIcon = 0;
		}
		else
			currentIcon++;

		switch(currentIcon)
		{
			case 0:
			fireIcon.SetActive(true);
			windIcon.SetActive(false);
			break;
			case 1:
			frostIcon.SetActive(true);
			fireIcon.SetActive(false);
			break;
			case 2:
			poisonIcon.SetActive(true);
			frostIcon.SetActive(false);
			break;
			case 3:
			windIcon.SetActive(true);
			poisonIcon.SetActive(false);
			break;
		}

	}
	public void cycleIconsBackward()
	{
		if(currentIcon == 0)
		{
			currentIcon = 3;
		}
		else
		{
			currentIcon--;
		}

		switch(currentIcon)
		{
			case 0:
			fireIcon.SetActive(true);
			frostIcon.SetActive(false);
			break;
			case 1:
			frostIcon.SetActive(true);
			poisonIcon.SetActive(false);
			break;
			case 2:
			poisonIcon.SetActive(true);
			windIcon.SetActive(false);
			break;
			case 3:
			windIcon.SetActive(true);
			fireIcon.SetActive(false);
			break;
		}
	}
}
