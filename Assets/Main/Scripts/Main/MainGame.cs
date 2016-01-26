using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour 
{
	public 	GameObject GamePrefab;
	public	GameObject menuScreen;
	public  GameObject scoreScreen;
	private bool GameIsRunning;
	public float score;
	public bool isHighscore;
	private	GUIStyle style;
	public	GUIStyle Style
	{
		get { return style; }
	}

	// Use this for initialization
	void Start () 
	{
		GameIsRunning = false;
		style = new GUIStyle("label");
		style.alignment = TextAnchor.MiddleCenter;
		style.normal.textColor = Color.white;
		style.font = (Font)Resources.Load("Iceland-Regular");
		style.fontSize = 60;
		score = 0;
	}

	public void OnGUI()
	{
		if (!GameIsRunning)
		{
			/*
			GUI.Label(
				new Rect(
				Screen.width/2 - Screen.width/10, 
				Screen.height/40,
				Screen.width/5, 40),
				"HIGHSCORE: " + score.ToString(),
				style);
				*/
		}
	}

	public void StartGame()
	{;
		GameObject.Instantiate(GamePrefab);
		GameIsRunning = true;

		menuScreen.SetActive(false);
	}

	public void EndGame(float newScore)
	{
		GameIsRunning = false;
		Instantiate (scoreScreen);
		Highscore(newScore);
		menuScreen.SetActive(true);
	}

	private void Highscore(float newScore)
	{
		if (newScore > score) {
			score = newScore;
			isHighscore = true;
		}
	}
}
