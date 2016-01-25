using UnityEngine;
using System.Collections;

public class showLives : MonoBehaviour {

	private Game current;
	private float x;
	public GameObject lifePrefab;

	private GameObject[] life;
	private Vector3 screenPos;

	// Use this for initialization
	void Start () {
		current = GameObject.FindGameObjectWithTag ("Game").GetComponent<Game> ();
		life = new GameObject[current.life];

		for (int i=0; i<current.life; i++) {
			life [i] = Instantiate (lifePrefab);
			life [i].transform.parent = gameObject.transform;
			life [i].GetComponent<Renderer>().sortingOrder = 1;
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {
		x = 18.0f;

		for (int i=0; i<life.Length; i++) {
			screenPos = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth - Screen.width/x, Camera.main.pixelHeight - Screen.height/9, 0));
			screenPos.z = 0;
			life[i].transform.position = screenPos;
			switch(i) {
			case 0:
				x = 10.0f;
				break;
			case 1:
				x = 7.0f;
				break;
			}

		}

	}
}
