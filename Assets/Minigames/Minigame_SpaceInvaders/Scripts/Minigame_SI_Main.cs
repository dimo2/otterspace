using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Minigame_SI_Main : MiniGame {

    public Minigame_SI_OtterShip ottership;
    public float SIscore;
    public float SIlive = 0f;

    private GUIStyle style;

    // Use this for initialization
    void Start () {
        SIscore = 0f;
        style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGUI()
    {
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 40),
            "Leben übrig: " + ottership.SIlive.ToString() + '\n' +
            "Punkte: " + SIscore.ToString(),
            style);
    }


}
