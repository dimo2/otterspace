using UnityEngine;
using System.Collections;

public class Pause_showLives : MonoBehaviour {
	
	private Game current;
	private float x;
	public GameObject lifePrefab;
	
	private GameObject[] life;
	
	// Use this for initialization
	void Start () {
		current = GameObject.FindGameObjectWithTag ("Game").GetComponent<Game> ();
		life = new GameObject[current.life];
		x = 0.0f;
		
		for (int i=0; i<current.life; i++) {
			life [i] = Instantiate (lifePrefab);
			life [i].transform.parent = gameObject.transform;
			life [i].transform.localPosition = new Vector3( x, 0, 0);
			life [i].GetComponent<Renderer>().sortingOrder = 1;
			x = x - 1.5f;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
