using UnityEngine;
using System.Collections;

public class Pause_Power : MonoBehaviour {

	private PauseButton pb;

	// Use this for initialization
	void Start () {
		pb = GameObject.Find ("PauseButton").GetComponent<PauseButton>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown() {
		pb.isPaused = false;
		Time.timeScale = 1;
		Destroy (transform.parent.gameObject);
	}
}


