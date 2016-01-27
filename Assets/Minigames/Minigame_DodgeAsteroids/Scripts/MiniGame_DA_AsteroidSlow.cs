using UnityEngine;
using System.Collections;

public class MiniGame_DA_AsteroidSlow : MonoBehaviour { // Beim Umbenennen in Unity aufpassen! Der Klassenname wird dann nicht verändert!

    Vector3 startPosition;
    Vector3 targetPosition;
    Vector3 rotation;
    private float time;
    private float speed; // wie viele Sekunden braucht der Asteroid von rechts nach links
    private float rotationSpeed;
    private float timeFactor;

    public GameObject brokenAsteroidPrefab;
    private GameObject asteroid;
    private bool destroy;
    private float rot1, rot2, rot3, rot4;

    // Use this for initialization
    void Start () {
        float startY = Random.Range(-5, 5);
        float endY = Random.Range(startY-5, startY+5);
        startPosition.Set(11, startY, 0);
        targetPosition.Set(-11, endY, 0);
        transform.localPosition = startPosition;
        rotationSpeed = Random.Range(-3, 3);
        timeFactor = transform.parent.GetComponent<MiniGame_DodgeAsteroids>().publicTimeFactor;
        speed = Random.Range(0.25f, 0.5f);
        speed = speed + (1 - timeFactor);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (!destroy)
        {
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time * speed);
            if (transform.localPosition == targetPosition) GameObject.Destroy(this.gameObject);

            rotation.Set(0, 0, transform.localEulerAngles.z + rotationSpeed);
            transform.localEulerAngles = rotation;
        }

        if (destroy)
        {
            asteroid.transform.GetChild(0).Translate( -(1.25f - timeFactor) * Time.deltaTime * 20, Time.deltaTime, 0, Space.World); // Space.World !
            asteroid.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(0).localEulerAngles.z + rot1 * Time.deltaTime);
            asteroid.transform.GetChild(1).Translate( -(1.25f - timeFactor) * Time.deltaTime * 10, -Time.deltaTime/3*3, 0, Space.World);
            asteroid.transform.GetChild(1).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(1).localEulerAngles.z + rot2 * Time.deltaTime);
            asteroid.transform.GetChild(2).Translate( -(1.25f - timeFactor) * Time.deltaTime * 10, Time.deltaTime/3, 0, Space.World);
            asteroid.transform.GetChild(2).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(2).localEulerAngles.z + rot3 * Time.deltaTime);
            asteroid.transform.GetChild(3).Translate( -(1.25f - timeFactor) * Time.deltaTime * 20, -Time.deltaTime/3*3, 0, Space.World);
            asteroid.transform.GetChild(3).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(3).localEulerAngles.z + rot4 * Time.deltaTime);
            if (time > 2) Destroy(this.gameObject);
        }
    }

    public void Destroy () {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);

        GameObject go = GameObject.Instantiate(brokenAsteroidPrefab);
        go.transform.parent = transform;
        go.transform.position = transform.position;
        go.transform.position = transform.position;

        this.gameObject.GetComponent<Collider2D>().enabled = false; // Polygon Collider disablen

        rot1 = Random.Range(200, 400);
        rot2 = Random.Range(200, 400);
        rot3 = Random.Range(200, 400);
        rot4 = Random.Range(200, 400);

        asteroid = go;
        destroy = true;
        time = 0;
    }
}
