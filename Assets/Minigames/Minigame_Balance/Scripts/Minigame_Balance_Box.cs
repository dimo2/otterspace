using UnityEngine;
using System.Collections;

public class Minigame_Balance_Box : MonoBehaviour {

	public float speed = 10.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	void Update() {

		// Die oberen beiden auskommentierten Zeilen sind zum Testen in Unity,
		// der Rest für die Android-Version.


		/* float translation = Input.GetAxis("Horizontal") * 0.02F;
		transform.Translate(translation, 0, 0); */

		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		// dir.z = Input.acceleration.x;
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		dir *= Time.deltaTime;
		transform.Translate(dir * speed);

	}
}
