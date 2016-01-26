using UnityEngine;
using System.Collections;

public class Minigame_FishNinja : MiniGame {

	public GameObject fish;
	private float createTime = 0.0f;
	private float period = 0.7f;

	private float countdown;

	private GameObject edge;
	private	GUIStyle style;
	public float tF;
	
	public int gameType = 0;


	// Use this for initialization
	void Start () {
		tF = timeFactor;
		countdown = 15.0F;
		style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
	
	// Update is called once per frame
	void Update () {

		createTime += Time.deltaTime;
		edge = transform.FindChild ("Edge").gameObject;
		Minigame_FishNinja_Edge edgeScript = edge.GetComponent<Minigame_FishNinja_Edge> ();

		createFish ();
		countdown -= Time.deltaTime;

		if (countdown <= 0.0F) {
			Score += transform.GetComponentInChildren<Minigame_FishNinja_Fish>().score;
			Score += (2 - timeFactor) * 15;
			Score = Mathf.Round (Score);
			Win ();
		}

		if (edgeScript.lost == true)
			Lose ();

	}


	private void createFish() {
		if (createTime > (0.7 * timeFactor)) {
			// createTime += period;

			GameObject go;
			go = GameObject.Instantiate(fish);
			go.transform.parent = transform;
			createTime = 0.0f;
		}
	}

	public void OnGUI()
	{
		if(Time.timeScale == 1) {
		GUI.Label(
			new Rect(
			Screen.width/2 - Screen.width/10, 
			Screen.height/40,
			Screen.width/5, 40),
			countdown.ToString("N0"),
			style);
		}
	}



}
