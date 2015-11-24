using UnityEngine;
using System.Collections;

public class Minigame_Memory_Karte : MonoBehaviour 
{
	private Sprite back;
	private Sprite front;

	public bool isFlipped;

	public void Create(Sprite _f, Sprite _b)
	{
		back = _b;
		front = _f;

		isFlipped = true;
	}
}
