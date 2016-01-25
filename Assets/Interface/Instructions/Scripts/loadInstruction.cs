using UnityEngine;
using System.Collections;

public class loadInstruction : MonoBehaviour {

	public GameObject drueckenPrefab;
	public GameObject drueckenziehenPrefab;
	public GameObject neigenPrefab;
	private string parentName;
	public bool instructionsOpen;

	// Use this for initialization
	void Start () {
		load ();
		transform.name = "Instructions";
		instructionsOpen = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void load() {

		GameObject instr;

		switch (gameObject.GetComponentInParent<connectInstructions> ().gameType) {
		case 0:
			instr = Instantiate(drueckenPrefab);
			instr.transform.parent = transform;
			instr.transform.localPosition = new Vector3 (0, 0, 0);
			break;
		case 1:
			instr = Instantiate(drueckenziehenPrefab);
			instr.transform.parent = transform;
			instr.transform.localPosition = new Vector3 (0, 0, 0);
			break;
		case 2:
			instr = Instantiate(neigenPrefab);
			instr.transform.parent = transform;
			instr.transform.localPosition = new Vector3 (0, 0, 0);
			break;
		default:
			break;		
		}



	}

	void OnMouseDown() {
		Destroy (gameObject);
		instructionsOpen = false;
		Time.timeScale = 1;
	}
}
