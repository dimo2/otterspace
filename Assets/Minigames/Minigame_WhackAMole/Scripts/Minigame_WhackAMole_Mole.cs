using UnityEngine;
using System.Collections;

public class Minigame_WhackAMole_Mole : MonoBehaviour 
{
	public Minigame_WhackAMole_Hole hole;
	
	private float up;
	private float down;
	
	private float time;
	private Vector3 startPos;
	private Vector3 targetPos;

	public void Init()
	{
		startPos = transform.localPosition;
		targetPos = startPos + new Vector3(0,1.3f,0);

		up = 0.5f;
		down = 1.5f;
	}

	void Update()
	{
		time += Time.deltaTime;
		if (time <= up)
		{
			transform.localPosition =
				Vector3.Lerp(startPos, targetPos, time/up);
		}
		else if (time >= down)
		{
			transform.localPosition =
				Vector3.Lerp(targetPos, startPos, (time-down)/up);
		}
		if (time >= down+up)
		{
			if (gameObject.name.Contains("WhackAMole_Mole")) hole.Lost();
			GameObject.Destroy(this.gameObject);
		}

	}

	void OnMouseDown()
	{
		hole.Clicked();
	}
}
