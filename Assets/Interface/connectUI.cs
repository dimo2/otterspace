using UnityEngine;
using System.Collections;

public class connectUI : MonoBehaviour {

	public GameObject UIprefab;
	// Use this for initialization
	void Start () {
		GameObject UI = Instantiate (UIprefab);
		UI.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
