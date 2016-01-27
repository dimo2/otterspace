using UnityEngine;
using System.Collections;

public class HighScoreScreen : MonoBehaviour {

	private float highscore;

	// Use this for initialization
	void Start () {

		transform.GetComponentInChildren<Canvas> ().worldCamera = Camera.main;

        if (PlayerPrefs.HasKey("highscore")) highscore = PlayerPrefs.GetFloat("highscore");
        else highscore = 0;

        showScore ();

    }
	
	// Update is called once per frame
	void Update () {
	}

	private void showScore() {
        //Debug.Log(GameObject.Find("Score_Text"));
		GameObject.Find("Score_Text").GetComponent<UnityEngine.UI.Text>().text = "Your Highscore";
		GameObject.Find("Score_Score").GetComponent<UnityEngine.UI.Text>().text = highscore.ToString();
	}

    void OnMouseDown() {
		Destroy (gameObject);
	}
}
