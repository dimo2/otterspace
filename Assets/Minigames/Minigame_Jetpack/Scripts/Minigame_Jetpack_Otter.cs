using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minigame_Jetpack_Otter : MonoBehaviour {

    public float lives;

    private float jetpackFuel;
    private float loseFuel;
    private float move;

    private List<GameObject> bubbles;
    public GameObject bubblePrefab;
    private GameObject bubble;


    // Use this for initialization
    void Start () {
        lives = 1;
        jetpackFuel = 100; //* timeFactor;
        loseFuel = 0;
        move = 0;

        bubbles = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {

        if (jetpackFuel <= 0)
        {
            lives = 0;
            return;
        }

        if (Input.GetMouseButton(0))
        {
            move = (Input.mousePosition.x / Screen.width) * 2 - 1; // Mapping des Mausklicks auf eine Range von -1 bis 1. -1 ist ganz links, 1 ist ganz rechts.
            if (move < 0)
            {
                move = Mathf.Abs(move);
                transform.localEulerAngles = new Vector3(0, 180, -move * 30);
            }
            else transform.localEulerAngles = new Vector3(0, 0, -move * 30);
            transform.Translate(move / 4, 0.2f, 0);
            loseFuel += Time.deltaTime;

            bubble = GameObject.Instantiate(bubblePrefab);
            bubble.transform.parent = transform.FindChild("Bubbles");
            bubble.transform.position = transform.FindChild("Bubbles").transform.position;
            bubbles.Add(bubble);
        }

        if (!Input.GetMouseButton(0))
        {
            transform.Translate(move / 2, -0.2f, 0);
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
    }

    void moveBubbles()
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbles[i].transform.localPosition += new Vector3(Random.Range(-0.1f, 0.1f), -0.5f, 0);
            bubbles[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, bubbles[i].GetComponent<SpriteRenderer>().color.a - 0.065f);
            bubbles[i].transform.localScale += new Vector3(0.03f, 0.03f, 0);
            bubbles[i].GetComponent<SpriteRenderer>().sortingOrder = Random.Range(9, 11);
        }

        if (bubbles.Count > 25) bubbles.Remove(bubbles[bubbles.Count]);
    }
}
