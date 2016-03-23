using UnityEngine;
using System.Collections;

public class Alienrow : MiniGame {

    public float minX = 2.5f;
    public float maxX = 12.5f;
    public float loseY = 5.0f;
    private float alienspeed ;
    public Transform myTransform;
    public bool nachRechts = true;
    public float loseSI = 3f;
    public bool lose = false;
    // Use this for initialization
    void Start () {

        loseSI = 3f;
        lose = false;

        if (timeFactor > 0.75f)
        {
            alienspeed = 3.5f;
        }
        if (timeFactor <= 0.75f)
        {
            alienspeed = 3.0f;
        }
        if (timeFactor <= 0.5f)
        {
            alienspeed = 2.0f;
        }
        if (timeFactor <= 0.25f)
        {
            alienspeed = 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 newPosition = transform.position;

        if (loseSI <= 0)
            lose = true;


            if (nachRechts == true)
        {

            transform.Translate(new Vector3(alienspeed * Time.deltaTime, 0, 0));



           if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                transform.Translate(new Vector3(0, -1, 0));
                nachRechts = false;
                loseSI -= 1;
            }
            
        }

        else if (nachRechts == false) {
            transform.Translate(new Vector3(alienspeed * Time.deltaTime * -1 , 0, 0));



            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                transform.Translate(new Vector3(0, -1, 0));
                nachRechts = true;
                loseSI -= 1;
            }
            


        }
    }
}
