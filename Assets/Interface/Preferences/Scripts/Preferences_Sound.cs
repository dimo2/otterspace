using UnityEngine;
using System.Collections;

public class Preferences_Sound : MonoBehaviour {

	private bool paused;
	public Sprite on;
	public Sprite off;
	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (!paused) {
			AudioListener.volume = 0;
			GetComponent<SpriteRenderer>().sprite = off;
			paused = true;
		} else {
			AudioListener.volume = 1;
			GetComponent<SpriteRenderer>().sprite = on;
			paused = false;
		}
	}
}
