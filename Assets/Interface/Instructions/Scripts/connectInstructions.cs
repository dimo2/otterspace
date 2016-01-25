using UnityEngine;
using System.Collections;

public class connectInstructions : MonoBehaviour {

	public GameObject instructionsPrefab;

	public int gameType; // 0: Drücken, 1: Drücken und ziehen, 2: Neigen

	void Awake() {

	}
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		
		GameObject instructions = Instantiate (instructionsPrefab);
		instructions.transform.parent = transform;
		instructions.transform.localPosition = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}


}
