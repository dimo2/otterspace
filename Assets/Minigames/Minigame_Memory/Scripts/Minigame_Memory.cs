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

	void Start()
	{
		Karten =
			new List<Minigame_Memory_Karte>();
		CreateField();
        cardOne = null;
        Score = 0;

        style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;
	}

	private void CreateField()
	{
		//erstellt für jede Grafik 2 Karten
		foreach (Sprite s in Kartenmotive)
		{
			for (int i=0; i < 2; i++)
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
			for(;;)
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
		}
	}

	private void CheckField()
	{
		bool win = true;
		for (int i = 0; i < Karten.Count; i++)
		{
			if (!Karten[i].isFlipped)
				win = false;
		}
		if (win)
			Win ();
	}

    public void OnGUI()
    {
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, style.font.lineHeight),
            "Pärchen gefunden " + Score.ToString() + "/" + Kartenmotive.Length,
            style);
    }

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
            }
            else
            {
                Score++;
                CheckField();
            }
        }
        cardOne = null;
    }
}
