using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour {

	private GameObject prototypeButton;
	private GameObject levelOneButton;
	private GameObject howToPlayButton;
	private GameObject backButton;
	private ArrayList buttonList = new ArrayList();
	private GameObject levelSelectMenu;
	public GameObject howToPlayMenu;
	private int counter;
	private int numButtons;
	private float nextInput;
	private bool onLevelSelect;

	void Start()
	{
		prototypeButton = GameObject.Find ("PrototypeButton");
		levelOneButton = GameObject.Find("LevelOneButton");
		backButton = GameObject.Find("BackButton");
		howToPlayButton = GameObject.Find ("HowToPlayButton");
		levelSelectMenu = GameObject.Find ("LevelSelectMenu");
		buttonList.Add (prototypeButton);
		buttonList.Add (levelOneButton);
		buttonList.Add (howToPlayButton);
		buttonList.Add (backButton);
		counter = 0;
		numButtons = buttonList.Count - 1;
		nextInput = Time.time;
		onLevelSelect = true;

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
	public void OnClickHowToPlay()
	{
		levelSelectMenu.SetActive (false);
		howToPlayMenu.SetActive (true);
		onLevelSelect = false;
	}
	public void OnClickHowToPlayBack()
	{
		levelSelectMenu.SetActive (true);
		howToPlayMenu.SetActive (false);
		onLevelSelect = true;
	}
	void Update()
	{
		CheckVerticalInput ();
	}
	void CheckVerticalInput ()
	{
		float move = Input.GetAxis ("Vertical");

		if((Time.time > nextInput) && onLevelSelect)
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
		else if (!onLevelSelect)
		{
			EventSystem.current.SetSelectedGameObject((GameObject)GameObject.Find("HowToPlayBackButton"),null);
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
