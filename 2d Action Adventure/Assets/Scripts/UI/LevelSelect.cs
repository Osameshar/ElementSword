using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour {

	private GameObject prototypeButton;
	private GameObject levelOneButton;
	private GameObject backButton;
	private ArrayList buttonList = new ArrayList();
	private int counter;
	private int numButtons;
	private float nextInput;

	void Start()
	{
		prototypeButton = GameObject.Find ("PrototypeButton");
		levelOneButton = GameObject.Find("LevelOneButton");
		backButton = GameObject.Find("BackButton");
		buttonList.Add (prototypeButton);
		buttonList.Add (levelOneButton);
		buttonList.Add (backButton);
		counter = 0;
		numButtons = buttonList.Count - 1;
		nextInput = Time.time;

	}
	public void OnClickLevelOne()
	{
		Application.LoadLevel("levelone");
	}
	public void OnClickBack()
	{
		Application.LoadLevel ("mainmenu");
	}
	public void OnClickPrototype()
	{
		Application.LoadLevel ("prototypeScene");
	}
	void Update()
	{
		CheckVerticalInput ();
	}
	void CheckVerticalInput ()
	{
		float move = Input.GetAxis ("Vertical");

		if(Time.time > nextInput)
		{
			if(move < 0)
			{
				incrementCounter();
				EventSystem.current.SetSelectedGameObject((GameObject)buttonList[counter], null);

			}
			else if(move > 0)
			{
				decrementCounter();
				EventSystem.current.SetSelectedGameObject((GameObject)buttonList[counter], null);
			}
			nextInput = Time.time + 2f;
		}
	}

	void incrementCounter ()
	{
		if (counter == numButtons) 
		{
			counter = 0;
		}
		else
			counter ++;
	}

	void decrementCounter ()
	{
		if (counter == 0) 
		{
			counter = numButtons;
		}
		else
			counter --;
	}
}
