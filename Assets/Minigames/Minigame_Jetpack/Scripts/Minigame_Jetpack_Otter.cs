using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_Jetpack_Otter : MonoBehaviour {

    private float timefactor;

    public float lives;

    private float jetpackFuel;
    private float loseFuel;
    private bool originClick;
    private Vector3 originPoint;
    private Vector3 move;

    private List<GameObject> bubbles;
    public GameObject bubblePrefab;
    private GameObject bubble;
    private float bubbleTime;

    public Sprite threeLives;
    public Sprite twoLives;
    public Sprite oneLive;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {

        timefactor = transform.parent.GetComponent<Minigame_Jetpack>().publicTimeFactor;

        lives = 3;
        jetpackFuel = 180;
        if (timefactor > 0.4f) jetpackFuel *= timefactor;
        else jetpackFuel *= 0.4f;
        loseFuel = 0;
        originClick = true;

        bubbles = new List<GameObject>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = threeLives;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0) && jetpackFuel > 0)
        {
            if (originClick == true)
            {
                originClick = false;
                originPoint = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0);
            }

            move = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0) - originPoint;
            move.x = Mathf.Clamp(move.x, -0.1f, 0.1f);
            move.y =  Mathf.Clamp(move.y, -0.1f, 0.1f);

            if (move.x < 0)
            {
                transform.localEulerAngles = new Vector3(0, 180, move.x * 150);
            }
            else transform.localEulerAngles = new Vector3(0, 0, -move.x * 150);
            transform.position += new Vector3(move.x * 95 * Time.deltaTime, move.y * 95 * Time.deltaTime, 0);
            loseFuel += Time.deltaTime;

            bubbleTime += Time.deltaTime;
            if (bubbleTime > 0.01f)
            {
                bubble = GameObject.Instantiate(bubblePrefab);
                bubble.transform.parent = transform.FindChild("Bubbles");
                bubble.transform.position = transform.FindChild("Bubbles").transform.position;
                bubbles.Add(bubble);
                bubbleTime = 0;
            }
        }

        if (!Input.GetMouseButton(0) || jetpackFuel <= 0)
        {
            originClick = true;
            transform.position += new Vector3(move.x * 90 * Time.deltaTime, -11 * Time.deltaTime, 0);
        }

        if (loseFuel >= 0.1)
        {
            jetpackFuel -= 1;
            loseFuel = 0;
        }

        moveBubbles();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Collision"))
        {
            lives = 0;
            return;
        }

        if (col.gameObject.name.Contains("Ufo"))
        {
            lives = 100;
            return;
        }

        if (!col.gameObject.name.Contains("Camera"))
        {
            lives -= 1;
            if (lives == 2) spriteRenderer.sprite = twoLives;
            else if (lives == 1) spriteRenderer.sprite = oneLive;
        }
    }

    void moveBubbles()
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbles[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f * jetpackFuel / 100 + 0.2f, bubbles[i].GetComponent<SpriteRenderer>().color.a - (5f - move.y * 8f) * Time.deltaTime);
            bubbles[i].transform.localPosition += new Vector3(Random.Range(-5f, 5f) * Time.deltaTime, -25f * Time.deltaTime, 0);
            bubbles[i].transform.localScale += new Vector3(1.5f * Time.deltaTime, 1.5f * Time.deltaTime, 0);
            bubbles[i].GetComponent<SpriteRenderer>().sortingOrder = Random.Range(9, 11);
        }

        while (bubbles.Count > 25 * (jetpackFuel/100))
        {
            Destroy(bubbles[0].gameObject);
            bubbles.RemoveAt(0);
        }

    }
}
