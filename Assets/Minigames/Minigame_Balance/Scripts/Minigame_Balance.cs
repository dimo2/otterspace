using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_Balance : MiniGame {
	
	private float countdown;
	private GameObject floor;
	private	GUIStyle style;
	private GameObject[] fish;


	public float tF;

	// Use this for initialization
	void Start () {
		countdown = 15.0F;
		style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		tF = timeFactor;

	}
	
	// Update is called once per frame
	void Update() {


		countdown -= Time.deltaTime;
		floor = transform.FindChild ("Floor").gameObject;
		Minigame_Balance_Floor floorScript = floor.GetComponent<Minigame_Balance_Floor> ();


		// Wenn der Countdown auf 0 ist, gewinnt man das Spiel.

		if (countdown <= 0.0F) {
			fish = GameObject.FindGameObjectsWithTag("Fish");
			for(int i=0;i<fish.Length;i++) Destroy(fish[i]);
			Score += (2 - timeFactor) * 15;
			Score = Mathf.Round(Score);
			Win ();

		}

		// Wenn die Box den Boden berührt, verliert man.

		if (floorScript.lost) {
			fish = GameObject.FindGameObjectsWithTag("Fish");
			for(int i=0;i<fish.Length;i++) Destroy(fish[i]);
			Lose ();

		}
	}


	public void OnGUI()
	{
		if (Time.timeScale == 1) {
			GUI.Label (
			new Rect (
			Screen.width / 2 - Screen.width / 10, 
			Screen.height / 40,
			Screen.width / 5, 40),
			countdown.ToString ("N0"),
			style);
		}
	}

}
