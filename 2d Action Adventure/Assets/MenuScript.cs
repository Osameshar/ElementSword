using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {

	private GameObject playButton;
	private GameObject quitButton;

	void Start()
	{
		playButton = GameObject.Find("PlayButton");
		quitButton = GameObject.Find("QuitButton");
	}
	public void OnClickPlay()
	{
		Application.LoadLevel("levelselect");
	}
	public void OnClickQuit()
	{
		Application.Quit ();
	}

	void Update()
	{
		CheckHorizontalInput ();
	}
	void CheckHorizontalInput ()
	{
		float move = Input.GetAxis ("Horizontal");
		if(move < 0)
		{
			EventSystem.current.SetSelectedGameObject(playButton, null);
		}
		else if(move > 0)
		{
			EventSystem.current.SetSelectedGameObject(quitButton, null);
		}

	}
}
