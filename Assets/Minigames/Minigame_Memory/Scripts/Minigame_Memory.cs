using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Minigame_Memory : MiniGame 
{
	private List<Minigame_Memory_Karte> Karten;
	public Sprite[] Kartenmotive;
	public Sprite	Kartenhintergrund;
	public GameObject prefabKarte;

    private GUIStyle style;

	public int rows;
	public int columns; 
    public float xPadding;
    public float yPadding;

    private int lives;
    private Vector2 translate;
    private bool showingCards;

	void Start()
	{
        if (timeFactor > 0.75f)
        {
            rows = 2;
            columns = 3;
        }
        if (timeFactor <= 0.75f)
        {
            rows = 2;
            columns = 4;
        }
        if (timeFactor <= 0.5f)
        {
            rows = 3;
            columns = 4;
        }
        if (timeFactor <= 0.25f)
        {
            rows = 4;
            columns = 4;
        }

        Karten =
			new List<Minigame_Memory_Karte>();
		CreateField();
        cardOne = null;
        Score = 0; 

        style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;

        lives = 3;
        translate = new Vector2(0,0);
        showingCards = true;

        StartCoroutine(ShowAll());
	}

	private void CreateField()
	{
        int chooseSprite;
        List<int> spriteTaken = new List<int>();
        Sprite s;
		//erstellt für jede Grafik 2 Karten
        for (int i = 0; i < (rows*columns)/2; i++)
		{
            chooseSprite = Random.Range(0, Kartenmotive.Length);
            while (spriteTaken.Contains(chooseSprite)) chooseSprite = Random.Range(0, Kartenmotive.Length);
            s = Kartenmotive[chooseSprite];
            spriteTaken.Add(chooseSprite);

            for (int j=0; j < 2; j++)
			{
				Minigame_Memory_Karte k = 
					GameObject.Instantiate(prefabKarte).GetComponent<Minigame_Memory_Karte>();
				k.Create(s, Kartenhintergrund, this);
				Karten.Add(k);
				k.gameObject.transform.parent = transform;
				k.gameObject.transform.localPosition = 
					new Vector3(0,10,0);
			}
		}
		ShuffleField();
	}

	private void ShuffleField()
	{
		int placed = 0;
		for (int i = 0; i < rows; i++)
			for (int j = 0; j < columns; j++)
		{
			if (placed >= Karten.Count)
				return;
			GameObject go;
			for(;;) // nächste Karte wird zufällig ausgewählt
			{
				int r = Random.Range(0,Karten.Count);
				go = Karten[r].gameObject;
				if (go.transform.localPosition.y == 10)
					break;
			}
			go.transform.localPosition = 
				new Vector3(
                    1.9f -((columns / 2) * xPadding) + (j * xPadding),
                    1 - ((rows / 2) * yPadding) + (i * yPadding));
			placed++;
            translate.x += go.transform.localPosition.x;
            translate.y += go.transform.localPosition.y;
		}
        translate /= Karten.Count;
        for (int i = 0; i < Karten.Count; i++) // Karten zentrieren
            Karten[i].transform.Translate(-translate.x, -translate.y, 0);
	}

    private IEnumerator ShowAll()
    {
        for (int i = 0; i < Karten.Count; i++)
        {
            Karten[i].Flip();
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < Karten.Count; i++)
        {
            Karten[i].Flip();
        }
        showingCards = false;

    }

    private void CheckField()
	{
		bool win = true;
		for (int i = 0; i < Karten.Count; i++)
		{
			if (!Karten[i].isFlipped)
				win = false;
		}
		if (win && !showingCards)
			Win ();
	}

	/*
    public void OnGUI()
    {
		if (Time.timeScale == 1) {
			GUI.Label (
            new Rect (
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 40), // style.font.lineHeight ergibt bei mir eine Null Reference Exeption
            "Pärchen gefunden " + Score.ToString () + "/" + (rows * columns) / 2 + '\n' + 
				"Leben: " + lives.ToString (),
            style);
		}
    }
    */

    private Minigame_Memory_Karte cardOne;
    public void ChoseCard(Minigame_Memory_Karte k)
    {
        if (cardOne == null)
        {
            cardOne = k;
            return;
        }
        else
        {
            if (cardOne.Front != k.Front)
            {
                cardOne.Flip();
                k.Flip();
                lives -= 1;
                if (lives == 0) Lose();
            }
            else
            {
                if (!showingCards) Score++;
                CheckField();
            }
        }
        cardOne = null;
    }
}
