using UnityEngine;
using System.Collections;

public class MiniGame_DA_AsteroidFast : MonoBehaviour {

    Vector3 startPosition;
    Vector3 targetPosition;
    private float time;
    private float speed; // wie viele Sekunden braucht der Asteroid von rechts nach links

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
        speed = 0.8f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!destroy)
        {
            time += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time / speed);
            if (transform.localPosition == targetPosition) GameObject.Destroy(this.gameObject);
        }
        if (destroy)
        {
            asteroid.transform.GetChild(0).Translate(-0.25f, 0.05f, 0, Space.World);
            asteroid.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(0).localEulerAngles.z + rot1);
            asteroid.transform.GetChild(1).Translate(-0.25f, -0.05f, 0, Space.World);
            asteroid.transform.GetChild(1).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(1).localEulerAngles.z + rot2);
            asteroid.transform.GetChild(2).Translate(-0.30f, 0.05f, 0, Space.World);
            asteroid.transform.GetChild(2).localEulerAngles = new Vector3(0, 0, asteroid.transform.GetChild(2).localEulerAngles.z + rot3);
            if (time > 2) Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);

        GameObject go = GameObject.Instantiate(brokenAsteroidPrefab);
        go.transform.parent = transform;
        go.transform.localPosition = transform.localPosition;
        go.transform.localRotation = transform.localRotation;

        this.gameObject.GetComponent<Collider2D>().enabled = false; // Polygon Collider disablen

        rot1 = Random.Range(6, 10);
        rot2 = Random.Range(6, 10);
        rot3 = Random.Range(6, 10);

        asteroid = go;
        destroy = true;
        time = 0;

    }
}
