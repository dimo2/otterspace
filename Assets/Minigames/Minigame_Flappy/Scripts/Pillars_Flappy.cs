using UnityEngine;
//using UnityEditor;
using System.Collections;

public class Pillars_Flappy : MiniGame {

    public GameObject pillars;
    public float pillarInterval = 2;


//	private List<GameObject> stars; // Für die dreist von Niko geklauten Background-Sterne

    int score = 0;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CreatePillar", pillarInterval, pillarInterval);


	}	

	void CreatePillar () {
        Instantiate(pillars).transform.parent = transform;
        score++;


	}

    public void IsLost()
    {
        Lose();
		//Debug.Log("bitte bitte bitte mach");
 //     EditorApplication.isPaused = true;
    }

    public void OnGUI()
    {
		/*
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 60),
            "Punkte: " + score);
            */
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))      //devkey
        {
			IsLost ();
            Score += 9999;
        }

        if (score == 10)
        {
            Win();
            Debug.Log("testsetst");
            Score += score;
        }


	}


}
