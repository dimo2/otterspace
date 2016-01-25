using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Minigame_SI_Main : MiniGame {
	
	private int leben;
    public float SIscore;

    private GUIStyle style;
	public float tF;

    // Use this for initialization
    void Start () {
		tF = timeFactor;
        SIscore = 0f;
        style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;

    }
	
	// Update is called once per frame
	void Update () {

		leben = transform.GetComponentInChildren<Minigame_SI_OtterShip> ().leben;

		if (transform.GetComponentInChildren<Minigame_SI_OtterShip>().otterdead)
		{
			Lose();
		}


		if (transform.GetComponentInChildren<Minigame_SI_randomshot> ().won) {
			Win ();
			Score += 30.0f;
		}
	}

/*
    public void OnGUI()
    {
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 40),
            "Leben übrig: " + leben.ToString(),
            style);
    }
    
*/

}
