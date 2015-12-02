using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Minigame_Memory : MiniGame 
{
	private List<Minigame_Memory_Karte> Karten;
	public Sprite[] Kartenmotive;
	public Sprite	Kartenhintergrund;
	public GameObject prefabKarte;

	public int rows;
	public int columns;

	void Start()
	{
		Karten =
			new List<Minigame_Memory_Karte>();
		CreateField();
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
				k.Create(s, Kartenhintergrund);
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
					-((-0.5f+(columns/2))*2.4f) + (j*2.4f),
					2f - (i * 2.2f));
			placed++;
		}
	}
}
