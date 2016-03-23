using UnityEngine;
using System.Collections;


public class Minigame_SI_OtterShip : MiniGame {
	public bool otterdead = false;
    public float SIlive = 3.0f;


	private float speed = 10f;
    private float delay = 0f;
	public float minX = -7.7f;
	public float maxX = 8.0f;

    public float schwierigkeit = 0f;
    public int leben;

    public GameObject bullet;
    public GameObject firingPoint;

    

    // Use this for initialization
    void Start () {
		leben = 1;
		otterdead = false;

        if (timeFactor > 0.75f)
        {
            schwierigkeit = 10f;
        }
        if (timeFactor <= 0.75f)
        {
            schwierigkeit = 20f;
        }
        if (timeFactor <= 0.5f)
        {
            schwierigkeit = 30f;
        }
        if (timeFactor <= 0.25f)
        {
            schwierigkeit = 35f;
        }
        Debug.LogError("Tf:" + timeFactor + ", schwierigkeit : " + schwierigkeit);
    }

    // Update is called once per frame

    void Update() {

		if (leben <= 0) {

			otterdead = true;
		
		}

		if (Application.isEditor) {
			Vector3 newPosition = transform.position;
			newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			transform.position = newPosition;

		
		if (transform.position.x < minX) {
			transform.position = new Vector3(minX, transform.position.y, transform.position.z);
		} else if (transform.position.x > maxX) {
			transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
		}
		} else {
			Vector3 dir = Vector3.zero;
			dir.x = Input.acceleration.x;
			// dir.z = Input.acceleration.x;
			if (dir.sqrMagnitude > 1)
				dir.Normalize ();
			
			dir *= Time.deltaTime;
			transform.Translate (dir * speed);

		
		if (transform.position.x < minX) {
			transform.position = new Vector3(minX, transform.position.y, transform.position.z);}
                else if (transform.position.x > maxX) {
			transform.position = new Vector3(maxX, transform.position.y, transform.position.z);}
		}



        if (Input.GetMouseButtonDown(0))
        {
            if (delay == 0) { 
                 GameObject shot = (GameObject)Instantiate(bullet, firingPoint.transform.position, Quaternion.identity);
                 shot.transform.parent = GameObject.Find("Minigame_SpaceInvaders(Clone)").transform;
                 delay = schwierigkeit;
            }
         }
        if (delay > 0)
        {
            delay -= 1;
        }
    }
   

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag.Contains("Otter")) {
			// Destroy(col.gameObject);
			leben--;

		}

	}



}



    


 