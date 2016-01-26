using UnityEngine;
using System.Collections;

public class MiniGame_DA_AsteroidFast : MonoBehaviour {

    Vector3 startPosition;
    Vector3 targetPosition;
    private float time;
    private float speed; // wie viele Sekunden braucht der Asteroid von rechts nach linksri
    private float timeFactor;

    public GameObject brokenAsteroidPrefab;
    private GameObject asteroid;
    private bool destroy;
    private float rot1, rot2, rot3;

    // Use this for initialization
    void Start () {
        float y = Random.Range(-5, 5);
        startPosition.Set(11, y, 0);
        targetPosition.Set(-11, y, 0);
        transform.localPosition = startPosition;
        timeFactor = transform.parent.GetComponent<MiniGame_DodgeAsteroids>().publicTimeFactor;
        Debug.Log(timeFactor);
        speed = 0.8f;
        speed = speed + (1 - timeFactor);
    }
	
	// Update is called once per frame
	void Update () {
        if (!destroy)
        {
            time += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time * speed);
            if (transform.localPosition == targetPosition) GameObject.Destroy(this.gameObject);
        }
        if (destroy)
        {
            asteroid.transform.GetChild(0).Translate(-13 * Time.deltaTime, 13 * Time.deltaTime/5, 0, Space.World);
            asteroid.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(0).localEulerAngles.z + rot1 * Time.deltaTime);
            asteroid.transform.GetChild(1).Translate(-13 * Time.deltaTime, -13 * Time.deltaTime / 5, 0, Space.World);
            asteroid.transform.GetChild(1).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(1).localEulerAngles.z + rot2 * Time.deltaTime);
            asteroid.transform.GetChild(2).Translate(-16f * Time.deltaTime, 13 * Time.deltaTime / 5, 0, Space.World);
            asteroid.transform.GetChild(2).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(2).localEulerAngles.z + rot3 * Time.deltaTime);
            if (time > 2) Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);

        GameObject go = GameObject.Instantiate(brokenAsteroidPrefab);
        go.transform.parent = transform;
        go.transform.position = transform.position;
        go.transform.position = transform.position;

        this.gameObject.GetComponent<Collider2D>().enabled = false; // Polygon Collider disablen

        rot1 = Random.Range(200, 400);
        rot2 = Random.Range(200, 400);
        rot3 = Random.Range(200, 400);

        asteroid = go;
        destroy = true;
        time = 0;

    }
}
