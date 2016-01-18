using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_Jetpack_Otter : MonoBehaviour {

    private float timefactor;

    public float lives;

    private float jetpackFuel;
    private float loseFuel;
    private float moveX;
    private float moveY;

    private List<GameObject> bubbles;
    public GameObject bubblePrefab;
    private GameObject bubble;
    private float bubbleTime;

    // Use this for initialization
    void Start () {

        timefactor = transform.parent.GetComponent<Minigame_Jetpack>().publicTimeFactor;

        lives = 3;
        jetpackFuel = 100;
        if (timefactor > 0.4f) jetpackFuel *= timefactor;
        else jetpackFuel *= 0.4f;
        loseFuel = 0;
        moveX = 0;
        moveY = 0;

        bubbles = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0) && jetpackFuel > 0)
        {
            moveX = (Input.mousePosition.x / Screen.width) * 2 - 1; // Mapping des Mausklicks auf eine Range von -1 bis 1. -1 ist ganz links, 1 ist ganz rechts.
            moveY = (Input.mousePosition.y / Screen.height) * 2 - 1; // Mapping des Mausklicks auf eine Range von -1 bis 1.
            if (moveX < 0)
                transform.localEulerAngles = new Vector3(0, 180, moveX * 30);
            else transform.localEulerAngles = new Vector3(0, 0, -moveX * 30);
            //transform.Translate(moveX * Time.deltaTime, moveY * 18 * Time.deltaTime, 0);
            transform.position += new Vector3(moveX * 22 * Time.deltaTime, moveY * 18 * Time.deltaTime, 0);
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
            transform.position += new Vector3(moveX * 22 * Time.deltaTime, -18 * Time.deltaTime, 0);
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
            lives -= 1;
    }

    void moveBubbles()
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbles[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f * jetpackFuel / 100 + 0.2f, bubbles[i].GetComponent<SpriteRenderer>().color.a - (5f - moveY*1.75f) * Time.deltaTime);
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
