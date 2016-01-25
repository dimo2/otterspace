using UnityEngine;
using System.Collections;

public class PreferencesButton : MonoBehaviour {

	public GameObject preferencesPrefab;
	private bool isOpen;
	// Use this for initialization
	void Start () {
		isOpen = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		if (isOpen == false) {
			GameObject prefs = Instantiate (preferencesPrefab);
			prefs.transform.parent = transform.parent.transform.parent;
			isOpen = true;
		} else {
			Destroy(GameObject.FindGameObjectWithTag("Prefs"));
			isOpen = false;
		}
	}
}
