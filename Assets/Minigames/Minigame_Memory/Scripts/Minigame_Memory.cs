using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Minigame_Memory : MiniGame 
{
	private List<Minigame_Memory_Karte> Karten;
	public Sprite[] Kartenmotive;
	public Sprite	Kartenhintergrund;
	public GameObject prefabKarte;

	void Start()
	{
		Karten =
			new List<Minigame_Memory_Karte>();
	}

	private void CreateField()
	{

	}
}
