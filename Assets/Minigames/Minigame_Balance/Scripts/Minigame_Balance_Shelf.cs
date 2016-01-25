using UnityEngine;
using System.Collections;

public class Minigame_Balance_Shelf : MonoBehaviour {

	private bool turn = false;
	private float rotation;

	// Use this for initialization
	void Start () {
		rotation = (1+(1-gameObject.GetComponentInParent<Minigame_Balance>().tF)) * 10.0f;
	}
	
	// Update is called once per frame
		void Update() {

		turnPlatform ();
	}

	void OnDestroy() {
		Time.timeScale = 1;
	}
	void turnPlatform() {
		
		float myRotation = Time.deltaTime * 2.5f * rotation;
		
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