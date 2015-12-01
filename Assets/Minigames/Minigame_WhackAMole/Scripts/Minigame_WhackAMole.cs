using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_WhackAMole : MiniGame 
{
	public int rows;
	public int columns;
	public float timeToAppear;
	private float time;

	public GameObject holePrefab;
	private List<Minigame_WhackAMole_Hole> holes;

	private	GUIStyle style;


	// Use this for initialization
	void Start () 
	{
		holes =
			new List<Minigame_WhackAMole_Hole>();
		CreateMap();
		timeToAppear *=
			timeFactor;

		style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		CheckHoles();
		if (time >= timeToAppear)
		{
			CreateMole();
			time = 0;
		}
		if (Score >= 20)
			Win();
	}

	public void OnGUI()
	{
		GUI.Label(
			new Rect(
			Screen.width/2 - Screen.width/10, 
			Screen.height/40,
			Screen.width/5, style.font.lineHeight),
			"Aliens gerettet " + Score.ToString() + "/20",
			style);
	}

	private void CreateMap()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				GameObject go =	
					GameObject.Instantiate(holePrefab);
				go.transform.parent = transform;
				go.transform.localPosition =
					new Vector3(
						-((-0.5f+(columns/2))*2.4f) + (j*2.4f),
						2f - (i * 2.2f) - (Mathf.Abs(3.5f-(j+1))*0.1f));
				go.GetComponent<Minigame_WhackAMole_Hole>().Sort(i);
				holes.Add(go.GetComponent<Minigame_WhackAMole_Hole>());
			}
		}
	}

	private void CheckHoles()
	{
		float s = 0;
		foreach (Minigame_WhackAMole_Hole h in holes)
		{
			if (h.lost)
				Lose();
			s += h.score;
		}
		Score = s;
	}

	private void CreateMole()
	{
		for(;;)
		{
			int r = Random.Range (0, holes.Count);
			if (!holes[r].taken)
			{
				holes[r].newMole();
				return;
			}
		}
	}
}
