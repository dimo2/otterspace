using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_Balance : MiniGame {
	
	private float countdown;
	private GameObject floor;
	private	GUIStyle style;

	// Use this for initialization
	void Start () {
		countdown = 15.0F;
		style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
	}
	
	// Update is called once per frame
	void Update() {

		countdown -= Time.deltaTime;
		floor = transform.FindChild ("Floor").gameObject;
		Minigame_Balance_Floor floorScript = floor.GetComponent<Minigame_Balance_Floor> ();


		// Wenn der Countdown auf 0 ist, gewinnt man das Spiel.

		if (countdown <= 0.0F) {
			Win ();
		}

		// Wenn die Box den Boden berührt, verliert man.

		if (floorScript.lost) {
			Lose ();
		}
	}


	public void OnGUI()
	{
		GUI.Label(
			new Rect(
			Screen.width/2 - Screen.width/10, 
			Screen.height/40,
			Screen.width/5, style.font.lineHeight),
			"Überlebe noch " + countdown.ToString("N0") + " Sekunden!",
			style);
	}

}
