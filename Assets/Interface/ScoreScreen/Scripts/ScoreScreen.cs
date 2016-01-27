using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {

	private float myScore;
	private float myHighscore;
	private Game g;
	private MainGame mg;

	// Use this for initialization
	void Start () {
		g = GameObject.FindGameObjectWithTag ("Game").GetComponent<Game> ();
		mg = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MainGame> ();

		transform.GetComponentInChildren<Canvas> ().worldCamera = Camera.main;

		showScore ();
        setHighscore(g.score);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void setHighscore(float gamescore)
    {

        string key = "highscore";
        bool haskey = PlayerPrefs.HasKey(key);
        float highscore = 0;

        if (haskey)
        {
            highscore = PlayerPrefs.GetFloat(key);
            if (highscore < gamescore)
            {
                PlayerPrefs.SetFloat(key, gamescore);
                highscore = gamescore;
                PlayerPrefs.Save();
            }
        }
        else PlayerPrefs.SetFloat(key, g.score);
    }

	private void showScore() {
		GameObject.Find("Score_Text").GetComponent<UnityEngine.UI.Text>().text = "Your Score";
		GameObject.Find ("Score_Score").GetComponent<UnityEngine.UI.Text>().text = g.score.ToString();
	}

    void OnMouseDown() {
		Destroy (gameObject);
	}
}
