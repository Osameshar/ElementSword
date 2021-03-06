﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject controlsMenu;
	public GameObject spellbookMenu;
	public GameObject spellbookPage1;
	public GameObject spellbookPage2;
	private GameObject inputManager;
	private bool isEnabled = false;
	public GameObject spellbookButton;
	public GameObject quitButton;
	public GameObject controlsButton;
	private ArrayList buttonList = new ArrayList();
	private int counter;
	private int numButtons;
	private float nextInput;
	
	void Start()
	{
		inputManager = GameObject.Find ("Input Manager");
		buttonList.Add (controlsButton);
		buttonList.Add (spellbookButton);
		buttonList.Add (quitButton);
		counter = 0;
		numButtons = buttonList.Count - 1;
		nextInput = Time.realtimeSinceStartup;
	}
	public void OnClickSpellbookNextPage1()
	{
		spellbookPage1.SetActive (false);
		spellbookPage2.SetActive (true);

	}
	public void OnClickSpellbookNextPage2()
	{
		spellbookPage2.SetActive (false);
		spellbookPage1.SetActive (true);		
	}
	public void OnClickControls()
	{
		pauseMenu.SetActive (false);
		controlsMenu.SetActive (true);
	}
	public void OnClickBackControls()
	{
		controlsMenu.SetActive(false);
		pauseMenu.SetActive (true);
	}
	public void OnClickBackSpellbook()
	{
		spellbookMenu.SetActive(false);
		pauseMenu.SetActive (true);
	}
	public void OnClickSpellBook()
	{
		pauseMenu.SetActive (false);
		spellbookMenu.SetActive (true);
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
		if(isEnabled)
		{
			CheckVerticalInput ();
		}
	}
	void CheckVerticalInput ()
	{
		float move = Input.GetAxis ("Vertical");
		
		if(Time.realtimeSinceStartup > nextInput)
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
			nextInput = Time.realtimeSinceStartup + 1f;
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
