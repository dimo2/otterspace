using UnityEngine;
using System.Collections;

public class Minigame_SI_Alienshot : MonoBehaviour {
	private float maxY = -7.0f;
	public float speed = -3.0f;

	void Start()
	{
		Vector3 zPosition = transform.position;
		zPosition.z = 0;
		transform.position = zPosition;
		transform.rotation = Quaternion.identity;
	}
	// Update is called once per frame
	void Update () {
		
		Vector3 newPosition = transform.position;
		newPosition.y +=  speed * Time.deltaTime;
		transform.position = newPosition;
		if (newPosition.y < maxY)
		{
			Destroy(this.gameObject);		
		}
	}


}
