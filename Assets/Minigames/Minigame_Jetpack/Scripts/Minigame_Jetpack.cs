using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_Jetpack : MiniGame
{

    public GameObject otterJetpackPrefab;
    public GameObject ufoPrefab;
    private GameObject Otter;
    private GameObject Camera;
    private GameObject Ufo;
    private GameObject smallUfo;
    private Vector3 cameraOffset;

    private List<GameObject> stars;
    public GameObject starPrefab;
    private float timeStars;

    private RaycastHit2D screenHit;
    private BoxCollider2D screenCollider;

    private List<GameObject> spacetrash;
    public GameObject SpaceTrash01Prefab;
    public GameObject SpaceTrash02Prefab;
    public GameObject SpaceTrash03Prefab;

    public float publicTimeFactor; // Für den Zugriff von anderen Scripts
    
    // Use this for initialization
    void Start()
    {
        Otter = GameObject.Instantiate(otterJetpackPrefab);
        Otter.transform.parent = transform;

        Ufo = GameObject.Instantiate(ufoPrefab);
        Ufo.transform.parent = transform;
        if (Random.Range(-1f, 1f) < 0) Ufo.transform.position = new Vector3(-22f, 23, 0);
        else Ufo.transform.position = new Vector3(20.5f, 23, 0);
        Ufo.layer = LayerMask.NameToLayer("Ignore Raycast");
        smallUfo = GameObject.Instantiate(ufoPrefab);
        smallUfo.transform.parent = transform.FindChild("Navigation").transform;
        smallUfo.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        smallUfo.GetComponent<PolygonCollider2D>().enabled = false;

        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraOffset = Camera.transform.position - Otter.transform.position;
        Camera.AddComponent<BoxCollider2D>();
        screenCollider = Camera.GetComponent<BoxCollider2D>();
        screenCollider.size = new Vector2(14.5f, 8.5f);

        if (Random.Range(-1f, 1f) < 0) Otter.transform.position = new Vector3(-20, -15, 0);
        else Otter.transform.position = new Vector3(27, -11, 0);

        GameObject go;

        stars = new List<GameObject>();
        for (int i = 0; i < 50; i++)
        {
            go = GameObject.Instantiate(starPrefab);
            go.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-6f, 8f), 0);
            float scale = Random.Range(-0.15f, 0.15f);
            if (scale > 0.075) go.transform.parent = transform.FindChild("StarsBig").transform;
            else if (scale > -0.075) go.transform.parent = transform.FindChild("StarsMiddle").transform;
            else go.transform.parent = transform.FindChild("StarsSmall").transform;
            go.transform.localScale = new Vector3(0.5f + scale, 0.5f + scale, 1);
            go.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 + scale * 2 - 0.3f);
            stars.Add(go);
        }
        timeStars = 0;

        spacetrash = new List<GameObject>();
        spacetrash.Add(SpaceTrash01Prefab);
        spacetrash.Add(SpaceTrash02Prefab);
        spacetrash.Add(SpaceTrash03Prefab);
        for (int i = 0; i < 10; i++)
        {
            go = GameObject.Instantiate(spacetrash[Random.Range(0, 3)]);
            go.transform.parent = transform.FindChild("SpaceTrash").transform;
        }

        publicTimeFactor = timeFactor;
    }

    // Update is called once per frame
    void Update()
    {

        if (Otter.GetComponent<Minigame_Jetpack_Otter>().lives == 0 || Otter.GetComponent<Minigame_Jetpack_Otter>().lives == 100)
        {
            Camera.transform.position = new Vector3(0, 1, -10);
            Destroy(Camera.GetComponent<BoxCollider2D>());
            foreach (Transform child in transform) Destroy(child.GetComponent<GameObject>());
            if (Otter.GetComponent<Minigame_Jetpack_Otter>().lives == 0)
                Lose();
            if (Otter.GetComponent<Minigame_Jetpack_Otter>().lives == 100)
            {
                Score += 15;
                Win();
            } 
            return;
        }

        Camera.transform.position = Otter.transform.position + cameraOffset;
        transform.FindChild("StarsBig").transform.position = new Vector3(Otter.transform.position.x - Otter.transform.position.x / 10, Otter.transform.position.y - Otter.transform.position.y / 16, 0);
        transform.FindChild("StarsMiddle").transform.position = new Vector3(Otter.transform.position.x - Otter.transform.position.x / 10, Otter.transform.position.y - Otter.transform.position.y / 18, 0);
        transform.FindChild("StarsSmall").transform.position = new Vector3(Otter.transform.position.x - Otter.transform.position.x / 10, Otter.transform.position.y - Otter.transform.position.y / 20, 0);

        timeStars += Time.deltaTime;
        for (int i = 0; i < stars.Count; i++)
        {
            float color = Mathf.Sin(timeStars * i * 0.2f) * 0.4f; // Sterneflackern Opacity
            stars[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, stars[i].GetComponent<SpriteRenderer>().color.a + color);
        }

        
        screenHit = Physics2D.Raycast(Ufo.transform.position, Otter.transform.position - Ufo.transform.position);
        if (screenHit.distance > 3.5f)
        {
            smallUfo.SetActive(true);
            smallUfo.transform.position = screenHit.point;
            smallUfo.transform.localScale = new Vector3(0.25f - (screenHit.distance / 100), 0.25f - (screenHit.distance / 100), 0);
            if (smallUfo.transform.localScale.x < 0) smallUfo.SetActive(false);
        }
        else smallUfo.SetActive(false);

    }

}
