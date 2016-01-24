using UnityEngine;
using System.Collections;

public class Minigame_SI_randomshot : MonoBehaviour {
	public float alldead = 1f;
    public float cooldown;
    private float dTime;
	public GameObject alienshot;
	// Use this for initialization
	void Start () 
    {
        dTime = 0f;
		cooldown = 2f;
		alldead = 1f;
        //cooldown eventuell mit Time Factor verknüpfen hier?
        //cooldown *= timeFactor;
	}
	
	// Update is called once per frame
	void Update () 
    {
        dTime += Time.deltaTime;
        if (dTime > cooldown)
        {
            dTime = 0f;
            Transform attackOrigin = 
                RandomInvader();
			Instantiate(alienshot, attackOrigin.transform.position, Quaternion.identity);
        }
	}
    
    Transform RandomInvader() 
    {                 
        GameObject[] allInvaders = GameObject.FindGameObjectsWithTag("Gegner");
		if (allInvaders.Length == 0f) {
			alldead -= 1f;
			return null;
		} else {
			return allInvaders[Random.Range(0, allInvaders.Length-1)].transform;
		}
	}	
}
