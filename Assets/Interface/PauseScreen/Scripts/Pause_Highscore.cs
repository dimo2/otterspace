using UnityEngine;
using System.Collections;

public class Pause_Highscore : MonoBehaviour {

	private	GUIStyle style;
	private float myScore;
	private float myHighscore;
	private Game g;
	private MainGame mg;
	private GUIStyle style2;

	// Use this for initialization
	void Start () {
	 style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
		style.fontSize = 30;


		g = GameObject.FindGameObjectWithTag ("Game").GetComponent<Game> ();
		mg = GameObject.FindGameObjectWithTag ("GameController").GetComponent<MainGame> ();
		setStyle ();

	}
	

	
	// Update is called once per frame
	void Update () {

	
	}

	public void OnGUI()
	{
		Rect text = new Rect (0, 0, Screen.width / 3, 40);
		Rect text2 = new Rect (0, 0, Screen.width / 3, 60);
		Rect highscore = new Rect (0, 0, Screen.width / 3, 40);
		Rect score = new Rect (0, 0, Screen.width / 3, 40);

		string t, t2;
		if (g.score > mg.score) {
			t = "New Highscore";
			t2 = "Old Highscore";
		} else {
			t = "Your Score";
			t2 = "Your Highscore";
		}

		text.center = new Vector2 (Screen.width/2 - Screen.width/15, Screen.height/2-Screen.height/20);
		GUI.Label(text, t, style);

		score.center = new Vector2 (Screen.width/2 - Screen.width/15, Screen.height/2+Screen.height/20);
		GUI.Label(score, g.score.ToString(), style);

		text2.center = new Vector2 (Screen.width/2 - Screen.width/15, Screen.height/2+Screen.height/6);
		GUI.Label(text2, t2, style2);

		highscore.center = new Vector2 (Screen.width/2 - Screen.width/15, Screen.height/2+Screen.height/4);
		GUI.Label(highscore, mg.score.ToString(), style);
			
	}

	private void setStyle() {
		style2 = new GUIStyle("label");
		style2.alignment = TextAnchor.MiddleCenter;
		style2.normal.textColor = Color.white;
		style2.font = (Font)Resources.Load("Iceland-Regular");
		style2.fontSize = 25;
	}
}
