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
	ArrayList buffFrames = new ArrayList();
	ArrayList debuffFrames = new ArrayList();
	int currentBuffIndex;
	int currentDebuffIndex;

	void Start () {
		findFrames ();
		setInactive ();
		constructArrayLists ();
		currentBuffIndex = 0;
		currentDebuffIndex = 0;
	}

	void constructArrayLists ()
	{
		buffFrames.Add (GameObject.Find ("Buff1"));
		buffFrames.Add (GameObject.Find ("Buff2"));
		buffFrames.Add (GameObject.Find ("Buff3"));
		buffFrames.Add (GameObject.Find ("Buff4"));
		buffFrames.Add (GameObject.Find ("Buff5"));
		debuffFrames.Add (GameObject.Find ("Debuff1"));
		debuffFrames.Add (GameObject.Find ("Debuff2"));
		debuffFrames.Add (GameObject.Find ("Debuff3"));
		debuffFrames.Add (GameObject.Find ("Debuff4"));
		debuffFrames.Add (GameObject.Find ("Debuff5"));

		int i = 0;
		foreach (GameObject g in buffFrames)
		{
			((GameObject)buffFrames[i]).SetActive(false);
			i++;
		}
		i = 0;
		foreach (GameObject g in debuffFrames)
		{
			((GameObject)debuffFrames[i]).SetActive(false);
			i++;
		}
	}

	void findFrames ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		fireStacks = GameObject.Find ("FireNumber");
		frostStacks = GameObject.Find ("FrostNumber");
		poisonStacks = GameObject.Find ("PoisonNumber");
		windStacks = GameObject.Find ("WindNumber");
		fireFrame = GameObject.Find ("FireDebuffIcon");
		frostFrame = GameObject.Find ("FrostDebuffIcon");
		poisonFrame = GameObject.Find ("PoisonDebuffIcon");
		windFrame = GameObject.Find ("WindBuffIcon");
	}

	void setInactive ()
	{
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
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("number1");
			break;
		case 2:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("number2");
			break;
		case 3:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("number3");
			break;
		case 4:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("number4");
			break;
		case 5:
			elementStacks.SetActive(true);
			elementFrame.SetActive(true);
			elementStacks.GetComponent<Image>().sprite = Resources.Load<Sprite>("number5");
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

    public void addBuffDebuff(BuffDebuff bd)
	{
		if(bd.GetIconLocation() == "Player")
		{
			((GameObject)buffFrames[currentBuffIndex]).SetActive(true);
			((GameObject)buffFrames[currentBuffIndex]).GetComponent<Image>().sprite = Resources.Load<Sprite>(bd.getIconName());
			currentBuffIndex++;
		}
		else if (bd.GetIconLocation() == "Enemy")
		{
			((GameObject)debuffFrames[currentDebuffIndex]).SetActive(true);
			((GameObject)debuffFrames[currentDebuffIndex]).GetComponent<Image>().sprite = Resources.Load<Sprite>(bd.getIconName());
			currentDebuffIndex++;
		}
	}
	public void removeBuffDebuff(BuffDebuff bd)
	{
		if(bd.GetIconLocation() == "Player")
		{
			currentBuffIndex--;
			((GameObject)buffFrames[currentBuffIndex]).SetActive(false);

		}
		else if (bd.GetIconLocation() == "Enemy")
		{
			currentDebuffIndex--;
			((GameObject)debuffFrames[currentDebuffIndex]).SetActive(false);

		}
	}
}
