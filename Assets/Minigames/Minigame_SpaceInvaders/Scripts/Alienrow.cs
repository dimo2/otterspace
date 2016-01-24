using UnityEngine;
using System.Collections;

public class Alienrow : MonoBehaviour {

    public float minX = 2.5f;
    public float maxX = 12.5f;
    private float alienspeed = 1.0f;
    public Transform myTransform;
    public bool nachRechts = true;

    // Use this for initialization
    void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPosition = transform.position;
        if (nachRechts == true)
        {

            transform.Translate(new Vector3(alienspeed * Time.deltaTime, 0, 0));



            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                transform.Translate(new Vector3(0, -1, 0));
                nachRechts = true;
            }
            else if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                transform.Translate(new Vector3(0, -1, 0));
                nachRechts = false;
            }

        }

        else if (nachRechts == false) {
            transform.Translate(new Vector3(alienspeed * Time.deltaTime * -1 , 0, 0));



            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                transform.Translate(new Vector3(0, -1, 0));
                nachRechts = true;
            }
            else if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                transform.Translate(new Vector3(0, -1, 0));
                nachRechts = false;
            }


        }
    }
}
