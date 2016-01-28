using UnityEngine;
using System.Collections;

public class PillarMovement : MiniGame
{
    public float PillarVelocity = 4;
    public float rngRangeMin = -1;
	public float rngRangeMax = 2;
    public Pillars_Flappy pillars;
    private Rigidbody2D PillarObject; 

    void Start()
    {
        PillarObject = GetComponent<Rigidbody2D>();

        PillarObject.velocity = new Vector2(-PillarVelocity, 0);
		transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(rngRangeMin,rngRangeMax), transform.position.z);

    }


    // LoseState - called IsLost in Hauptscript und gibt Losestate bei Kollision
 /*   void OnCollisionEnter2D(Collision2D col)
    {
		Debug.Log("call das doch du spacko");
        pillars.IsLost();

    }
*/
    // Update is called once per frame
    void Update()
    {

    }
	void OnBecameInvisible(){
		Destroy(gameObject);
	}

}
