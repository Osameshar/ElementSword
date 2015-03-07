using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {
	
	public GameObject pauseMenu;
	private GameObject inputManager;
	private bool isEnabled = false;
	private GameObject spellbookButton;
	private GameObject quitButton;
	private ArrayList buttonList = new ArrayList();
	private int counter;
	private int numButtons;
	private float nextInput;
	
	void Start()
	{
		inputManager = GameObject.Find ("Input Manager");
		spellbookButton = GameObject.Find ("SpellbookButton");
		quitButton = GameObject.Find("QuitButton");
		buttonList.Add (spellbookButton);
		buttonList.Add (quitButton);
		counter = 0;
		numButtons = buttonList.Count - 1;
		nextInput = Time.time;
	}
	public void OnClickSpellBook()
	{

	}
	public void OnClickQuit()
	{
		setActiveFalse ();
		Application.LoadLevel ("mainmenu");
	}
	void Update()
	{		
		// Enable pause menu
		if (Input.GetButtonDown("Pause") && !isEnabled)
		{
			setActiveTrue ();
		}		
		// disable pause menu
		else if (Input.GetButtonDown("Pause") && isEnabled)
		{
			setActiveFalse ();
		}
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
			nextInput = Time.time + 1f;
		}
	}

	void setActiveFalse ()
	{
		inputManager.SetActive (true);
		pauseMenu.SetActive (false);
		Time.timeScale = 1.0f;
		isEnabled = false;

	}

	void setActiveTrue ()
	{
		inputManager.SetActive (false);
		pauseMenu.SetActive (true);
		Time.timeScale = 0.0f;
		isEnabled = true;

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
