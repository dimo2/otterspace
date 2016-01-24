using UnityEngine;
using System.Collections;

public class Minigame_SI_randomshot : MonoBehaviour {

    public float cooldown;
    private float dTime;
	// Use this for initialization
	void Start () 
    {
        dTime = 0;
        //cooldown eventuell mit Time Factor verknüpfen hier?
        //cooldown *= timeFactor;
	}
	
	// Update is called once per frame
	void Update () 
    {
        dTime += Time.deltaTime;
        if (dTime > cooldown)
        {
            dTime = 0;
            Transform attackOrigin = 
                RandomInvader();
            //Jetzt machst du hier was mit dem Transform
        }
	}
    
    Transform RandomInvader() 
    {                 
        GameObject[] allInvaders = GameObject.FindGameObjectsWithTag("Gegner");
		if (allInvaders.Length == 0) {
			return null;
		} else {
			return allInvaders[Random.Range(0, allInvaders.Length-1)].transform;
		}
	}	
}
