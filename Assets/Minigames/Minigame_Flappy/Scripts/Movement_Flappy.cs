using UnityEngine;
using System.Collections;

public class Movement_Flappy : MiniGame
{

    public Vector2 flap = new Vector2(0, 300);

	public Pillars_Flappy script;

    // Update is called once per frame

	void Start(){
		script = GetComponentInParent<Pillars_Flappy>();
	}
    void Update()
    // Flap bei Input
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            GetComponent<Rigidbody2D>().AddForce(flap);

        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log("is collided");
		script.IsLost ();

	}

	void OnBecameInvisible(){
		script.IsLost ();
	}

}