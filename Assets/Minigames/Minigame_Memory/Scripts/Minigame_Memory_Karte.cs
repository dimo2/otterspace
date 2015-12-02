using UnityEngine;
using System.Collections;

public class Minigame_Memory_Karte : MonoBehaviour 
{
	private Sprite back;
	private Sprite front;
	private SpriteRenderer sr;

	public bool isFlipped;
	public float flipTime;

	public void Create(Sprite _f, Sprite _b)
	{
		back = _b;
		front = _f;

		isFlipped = false;
		sr = GetComponent<SpriteRenderer>();
	}

	public void OnMouseDown()
	{
		Flip();
	}

	public void Flip()
	{
		StopCoroutine(Flipping());
		StartCoroutine(Flipping());
	}

	private void SwitchMotive()
	{
		if (!isFlipped)
			sr.sprite = front;
		else
			sr.sprite = back;
		isFlipped = !isFlipped;
	}

	private IEnumerator Flipping()
	{
		float elapsedTime = 0;
		float startPoint = 
			transform.localScale.y; //Falls während des Flippens neu geflippt wird
		while (elapsedTime < flipTime)
		{
			transform.localScale = 
				new Vector3(Mathf.Lerp(startPoint, 0, (elapsedTime/flipTime)), 1, 1);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		SwitchMotive();
		elapsedTime = 0;
		while (elapsedTime < flipTime)
		{
			transform.localScale = 
				new Vector3(Mathf.Lerp(0, 1, (elapsedTime/flipTime)), 1, 1);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
}
