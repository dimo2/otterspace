using UnityEngine;
using System.Collections;

public class Minigame_SI_block : MonoBehaviour {
	public float resistenz = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (resistenz <= 0) {
			Destroy (this.gameObject);

		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Contains("Otter")) {
			Destroy(col.gameObject);
			resistenz--;

		}

	}

}
