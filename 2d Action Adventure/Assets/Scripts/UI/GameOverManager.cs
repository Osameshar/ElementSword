using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	public Stats stats;       // Reference to the player's health.
	public float restartDelay = 10f;         // Time to wait before restarting the level
	
	
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	
	
	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
		stats = GameObject.FindGameObjectWithTag ("Player").GetComponent<Stats> ();
	}
	
	
	void Update ()
	{
		// If the player has run out of health...
		if(stats.getHealth() <= 0)
		{
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");
			
			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			
			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}