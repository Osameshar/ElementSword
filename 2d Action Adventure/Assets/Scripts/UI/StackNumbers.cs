using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StackNumbers : MonoBehaviour {

	// Use this for initialization

	GameObject player;
	GameObject currentTarget;
	GameObject fireStacks;
	GameObject frostStacks;
	GameObject poisonStacks;
	GameObject windStacks;
	GameObject fireFrame;
	GameObject frostFrame;
	GameObject poisonFrame;
	GameObject windFrame;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		fireStacks = GameObject.Find ("FireNumber");
		frostStacks = GameObject.Find ("FrostNumber");
		poisonStacks = GameObject.Find ("PoisonNumber");
		windStacks = GameObject.Find ("WindNumber");
		fireFrame = GameObject.Find ("FireDebuffIcon");
		frostFrame = GameObject.Find ("FrostDebuffIcon");
		poisonFrame = GameObject.Find ("PoisonDebuffIcon");
		windFrame = GameObject.Find ("WindBuffIcon");
		fireStacks.SetActive (false);
		frostStacks.SetActive (false);
		poisonStacks.SetActive (false);
		windStacks.SetActive (false);
		fireFrame.SetActive(false);
		frostFrame.SetActive(false);
		poisonFrame.SetActive(false);
		windFrame.SetActive(false);

	}

	void Update () {
		if(currentTarget != null)
		{
			updateIcons ();
		}
	}
	public void updateElementStacks(int numStacks, GameObject elementStacks, GameObject elementFrame)
	{
		switch(numStacks)
		{
		case 0:
			elementStacks.SetActive(false);
			elementFrame.SetActive(false);
			break;
		case 1:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("numberone");
			break;
		case 2:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("numbertwo");
			break;
		case 3:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("numberthree");
			break;
		case 4:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("numberfour");
			break;
		case 5:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("numberfive");
			break;
		}
	}	

	void updateIcons ()
	{
		int[] numStacks = currentTarget.GetComponent<BuffDebuffManager> ().GetElementStacks ();
		int numWindStacks = player.GetComponent<BuffDebuffManager> ().GetElementStacks ()[3];
		updateElementStacks (numStacks[0],fireStacks,fireFrame);
		updateElementStacks (numStacks[1],frostStacks,frostFrame);
		updateElementStacks (numStacks[2],poisonStacks,poisonFrame);
		updateElementStacks (numWindStacks,windStacks,windFrame);
	}

	public void updateIconsOnHit (GameObject target)
	{
		currentTarget = target;
		int[] numStacks = target.GetComponent<BuffDebuffManager> ().GetElementStacks ();
		int numWindStacks = player.GetComponent<BuffDebuffManager> ().GetElementStacks ()[3];
		updateElementStacks (numStacks[0],fireStacks,fireFrame);
		updateElementStacks (numStacks[1],frostStacks,frostFrame);
		updateElementStacks (numStacks[2],poisonStacks,poisonFrame);
		updateElementStacks (numWindStacks,windStacks,windFrame);
	}
}
