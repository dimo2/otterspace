using UnityEngine;
using System.Collections;

public class Minigame_FishNinja_Edge : MonoBehaviour {

	public bool lost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D ( Collider2D other ) {
		lost = true;
	}
}
