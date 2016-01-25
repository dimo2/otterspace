using UnityEngine;
using System.Collections;

public class Preferences_Sound : MonoBehaviour {

	private bool paused;
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
			paused = true;
		} else {
			AudioListener.volume = 1;
			paused = false;
		}
	}
}
