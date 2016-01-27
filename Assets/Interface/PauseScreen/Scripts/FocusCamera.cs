using UnityEngine;
using System.Collections;

public class FocusCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.transform.position = new Vector3 (0.0f, 1.0f, -10.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
