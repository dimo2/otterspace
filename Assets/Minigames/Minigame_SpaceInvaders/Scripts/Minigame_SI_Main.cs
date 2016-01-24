using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Minigame_SI_Main : MiniGame {

    public Minigame_SI_OtterShip ottership;
	public Minigame_SI_randomshot aliens;
    public float SIscore;

    private GUIStyle style;

    // Use this for initialization
    void Start () {
        SIscore = 0f;
        style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
		//ottership = GetComponent<MiniGame_DA_OtterUfo>();
		aliens = GetComponent<Minigame_SI_randomshot>();
    }
	
	// Update is called once per frame
	void Update () {
		if (ottership.leben <= 0)
		{
			Lose();
			foreach (Transform child in transform) Destroy(child.GetComponent<GameObject>()); // Für jedes Transform item(child) in transform.
		}
		if (aliens.alldead <= 0)
		{
			Win();
			foreach (Transform child in transform) Destroy(child.GetComponent<GameObject>()); // Für jedes Transform item(child) in transform.
		}
	}

    public void OnGUI()
    {
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 40),
            "Leben übrig: " + ottership.leben.ToString() + '\n' +
            "Punkte: " + SIscore.ToString(),
            style);
    }


}
