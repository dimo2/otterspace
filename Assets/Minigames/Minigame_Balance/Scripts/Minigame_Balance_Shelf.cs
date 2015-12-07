using UnityEngine;
using System.Collections;

public class Minigame_Balance_Shelf : MonoBehaviour {

	private bool turn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
		void Update() {

		turnPlatform ();
	}


	void turnPlatform() {
		
		float myRotation = Time.deltaTime * 25;
		
		if ((transform.eulerAngles.z <= 45 || transform.eulerAngles.z >= 305) && turn == false) {
			transform.Rotate (0, 0, myRotation);
		} else {
			transform.Rotate (0, 0, -myRotation);
			if(transform.eulerAngles.z >=305 && transform.eulerAngles.z <= 315) {
				turn = false;
			} else 
				turn = true;
		}
	}

}