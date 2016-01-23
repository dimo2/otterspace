﻿using UnityEngine;
using System.Collections;

public class Minigame_Button_Win : MiniGame {
	public float clicked = 0f;

    void onMouseDown()
	{
		clicked = 2f;
        //foreach (Transform child in transform) Destroy(child.GetComponent<GameObject>()); // Für jedes Transform item(child) in transform.
        //Score += 10; // Vorläufiger Score. Wird geändert, wenn wir genau wissen, wie das aussehen soll!
        //Score = Mathf.Round(Score);

    }
			
	void Update(){
		if (clicked >= 1f) 
		{
			Lose ();
			//foreach (Transform child in transform) Destroy(child.GetComponent<GameObject>()); // Für jedes Transform item(child) in transform.
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("LoseButton"))
        {
            col.transform.localPosition = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 4f), 0);    
        }
    
    }
}
