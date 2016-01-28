using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Pillars_Flappy : MiniGame {

    public GameObject pillars;
    public float pillarInterval = 2;

    private List<GameObject> stars;
    public GameObject starPrefab;
    private float time;

    //	private List<GameObject> stars; // Für die dreist von Niko geklauten Background-Sterne

    int score = 0;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CreatePillar", pillarInterval, pillarInterval);

        GameObject go;
        stars = new List<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            go = GameObject.Instantiate(starPrefab);
            go.transform.parent = transform.FindChild("Sterne").transform;
            go.transform.localPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 6f), 0);
            float scale = Random.Range(-0.15f, 0.15f);
            go.transform.localScale = new Vector3(0.5f + scale, 0.5f + scale, 1);
            go.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 + scale * 2 - 0.3f);
            if (0.5f + scale <= 0.5f) go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            stars.Add(go);
        }
        time = 0;

    }	

	void CreatePillar () {
        Instantiate(pillars).transform.parent = transform;
        score++;


	}

    public void IsLost()
    {
        Lose();
		//Debug.Log("bitte bitte bitte mach");
 //     EditorApplication.isPaused = true;
    }

    public void OnGUI()
    {
		/*
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 60),
            "Punkte: " + score);
            */
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))      //devkey
        {
			IsLost ();
            Score += 9999;
        }

        if (score == 10)
        {
            Win();
            //Debug.Log("testsetst");
            Score += score;
        }

        time += Time.deltaTime;
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].transform.Translate((-stars[i].transform.localScale.x * Time.deltaTime), 0, 0); // Je größer der Stern, desto schneller soll er sich bewegen.
            if (stars[i].transform.localPosition.x < -9f) stars[i].transform.localPosition = new Vector3(9f, stars[i].transform.localPosition.y, 0);
            float color = Mathf.Sin(time * i * 0.2f) * 0.4f; // Sterneflackern Opacity
            stars[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, stars[i].GetComponent<SpriteRenderer>().color.a + color);
        }


    }


}
