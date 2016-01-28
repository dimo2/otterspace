using UnityEngine;
using System.Collections;

public class Preferences_Highscore : MonoBehaviour {

    public GameObject HighscoreScreen;
    private GameObject screen;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (transform.parent.Find("HighScoreScreen(Clone)") == null)
        {
            screen = GameObject.Instantiate(HighscoreScreen);
            screen.transform.parent = transform.parent;
        }
    }
}
