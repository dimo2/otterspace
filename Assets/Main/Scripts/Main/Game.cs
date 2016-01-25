using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour 
{
	public float 	score;
	private float	timeFactor;
	private int		gamesCompleted;

	public 	List<GameObject> games;
	private MiniGame g; //Aktuelles Minigame
	private	MainGame mg; //Verweis auf das Haupt Game Objekt

	public enum State { WAITING, LOADING, RUNNING};
	private State state;
	private float waitTime;
	public	float timeToWait;
	public int 	life;

	public AudioClip music;
	
	public void Start()
	{
		g = null;
		life = 3;
		score = 0;
		timeFactor = 1;
		gamesCompleted = 0;
		timeToWait = 2.5f;

		mg = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>();
		gameObject.tag = "Game";


	}
	 
	private MiniGame GetGame()
	{
		int r = Random.Range(0, games.Count);
		GameObject g = GameObject.Instantiate(games[r]);
		return g.GetComponent<MiniGame>();
	}

	private void Update()
	{
		AudioSource audio = GetComponent<AudioSource> ();

		switch (state)
		{
		case State.WAITING:
			waitTime += Time.deltaTime;
			if (waitTime > timeToWait)
				state = State.LOADING;
			break;

		case State.LOADING:
			g = GetGame();
			g.StartGame(timeFactor);
			addAudio();
			state = State.RUNNING;
			break;

		case State.RUNNING:
			switch (g.GetState())
			{
			case MiniGame.State.RUNNING:
				break;
			case MiniGame.State.WON:
				score += g.Score;
				gamesCompleted ++;
				CalculateTimeFactor();
				g.Destroy();
				g = null;
				audio.Play ();
				state = State.WAITING;
				waitTime = 0;
				break;
			case MiniGame.State.LOST:
				life --;
				if (life == 0)
					GameOver();
				g.Destroy();
				g = null;
				audio.Play ();
				state = State.WAITING;
				waitTime = 0;
				break;
			}
			break;
		} 
	}

	public void OnGUI()
	{
		if (state == State.WAITING)
		{
			GUI.Label(
				new Rect(
				Screen.width/2 - Screen.width/6, 
				Screen.height/2 - Screen.height/12,
				Screen.width/3, Screen.height/6),
				GetInformation(), mg.Style);
		}
	}

	private void GameOver()
	{
		mg.EndGame(score);
		Destroy(this.gameObject);
	}

	private void CalculateTimeFactor()
	{
		timeFactor = 1 - (0.75f * gamesCompleted/20.0f);
		if (timeFactor < 0.25f)
			timeFactor = 0.25f;
	}

	private string GetInformation()
	{
		string s = gamesCompleted + " Games beendet";
		return s;
	}


	private void addAudio() {
		AudioSource audioSource = g.gameObject.AddComponent<AudioSource>();
		audioSource.clip = music;
		audioSource.loop = true;
		audioSource.Play ();
	}
}
