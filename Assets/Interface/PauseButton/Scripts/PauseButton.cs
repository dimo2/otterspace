using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public bool isPaused = false;
	public GameObject pauseScreen;
	
	private Vector3 screenPos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		screenPos = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width/8,Camera.main.pixelHeight-Screen.height/9,0));
		screenPos.z = 0;
		transform.position = screenPos;

	}

	void OnMouseDown() {
		PauseGame ();
	}

	private void PauseGame() {
		if (isPaused == false)
		{
			Instantiate(pauseScreen);
			Time.timeScale = 0;
			isPaused = true;
		}
	}

}
