using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour 
{
	public 	GameObject GamePrefab;
	public	GameObject menuScreen;
	private bool GameIsRunning;
	private float score;
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
		score = 0;
	}

	public void OnGUI()
	{
		if (!GameIsRunning)
		{
			GUI.Label(
				new Rect(
				Screen.width/2 - Screen.width/10, 
				Screen.height/40,
				Screen.width/5, style.font.lineHeight),
				"HIGHSCORE: " + score.ToString(),
				style);
		}
	}

	public void StartGame()
	{
		GameObject.Instantiate(GamePrefab);
		GameIsRunning = true;

		menuScreen.SetActive(false);
	}

	public void EndGame(float newScore)
	{
		GameIsRunning = false;
		Highscore(newScore);

		menuScreen.SetActive(true);
	}

	private void Highscore(float newScore)
	{
		if (newScore > score)
			score = newScore;
	}
}
