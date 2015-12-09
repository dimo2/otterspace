using UnityEngine;
using System.Collections;

public class Minigame_Balance_Floor : MonoBehaviour {

	public bool lost;
	
	void OnTriggerEnter2D(Collider2D other) {
		lost = true;
	}
}
