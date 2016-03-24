using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Minigame_SI_Main : MiniGame {
	
	private int leben;
    public float SIscore;

    private List<GameObject> stars;
    public GameObject starPrefab;
    private float timeStars;

    public GameObject mondPrefab;
    private GameObject mond;
	private GameObject[] fish;

	public float timeF;
    private float time2;

    // Use this for initialization
    void Start () {
        GameObject go;
 

        timeF = timeFactor;
        

       
        time2 = 0;

        stars = new List<GameObject>();
        for (int i = 0; i < 60; i++)
        {
            go = GameObject.Instantiate(starPrefab);
            go.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-6f, 8f), 0);
            float scale = Random.Range(-0.15f, 0.15f);
            
            go.transform.localScale = new Vector3(0.5f + scale, 0.5f + scale, 1);
            go.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 + scale * 2 - 0.3f);
            stars.Add(go);
        }
        timeStars = 0;

        go = GameObject.Instantiate(mondPrefab);

        go.transform.localPosition = new Vector3(8, Random.Range(-5f, 8f), 0);
        mond = go;



        if (timeFactor > 0.75f)
        {
            SIscore = 20f;
            Debug.LogError("Tf:" + timeFactor + ", Score : " + SIscore);
        }
        else if (timeFactor <= 0.75f)
        {
            SIscore = 30f;
            Debug.LogError("Tf:" + timeFactor + ", Score : " + SIscore);
        }
        else if (timeFactor <= 0.5f)
        {
            SIscore = 40f;
            Debug.LogError("Tf:" + timeFactor + ", Score : " + SIscore);
        }
        else if (timeFactor <= 0.25f)
        {
            SIscore = 50f;
            Debug.LogError("Tf:" + timeFactor + ", Score : " + SIscore);
        }
    }
	
	// Update is called once per frame
	void Update () {

		leben = transform.GetComponentInChildren<Minigame_SI_OtterShip> ().leben;

		if (transform.GetComponentInChildren<Minigame_SI_OtterShip>().otterdead)
		{
			fish = GameObject.FindGameObjectsWithTag("Fish");
			for(int i=0;i<fish.Length;i++) Destroy(fish[i]);
			Lose();
		}
        if (transform.GetComponentInChildren<Alienrow>().lose)
        {
            fish = GameObject.FindGameObjectsWithTag("Fish");
            for (int i = 0; i < fish.Length; i++) Destroy(fish[i]);
            Lose();

        }


        if (transform.GetComponentInChildren<Minigame_SI_randomshot> ().won) {
			fish = GameObject.FindGameObjectsWithTag("Fish");
			for(int i=0;i<fish.Length;i++) Destroy(fish[i]);
			Score += SIscore;
			Win ();

		}

        
        timeStars += Time.deltaTime;
        for (int i = 0; i < stars.Count; i++)
        {
            float color = Mathf.Sin(timeStars * i * 0.2f) * 0.4f; // Sterneflackern Opacity
            stars[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, stars[i].GetComponent<SpriteRenderer>().color.a + color);
        }

        mond.transform.Translate(Vector3.left * Time.deltaTime * 0.3f);
        mond.transform.localEulerAngles = new Vector3(0, 0, mond.transform.localEulerAngles.z + 0.017f);
    }



}
