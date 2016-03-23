using UnityEngine;
using System.Collections;

public class Minigame_SI_randomshot : MiniGame {
	public float alldead = 1f;
    public float cooldown;
    private float dTime;
	public bool won;
	public GameObject alienshot;

	// Use this for initialization
	void Start () 
    {
		won = false;
        dTime = 0f;
        if (timeFactor > 0.75f)
        {
            cooldown = 0.5f;
        }
        if (timeFactor <= 0.75f)
        {
            cooldown = 1.0f;
        }
        if (timeFactor <= 0.5f)
        {
            cooldown = 1.5f;
        }
        if (timeFactor <= 0.25f)
        {
            cooldown = 2f;
        }
        alldead = 1f;
        //cooldown eventuell mit Time Factor verknüpfen hier?
        cooldown *= transform.GetComponentInParent<Minigame_SI_Main>().tF;
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
			GameObject shot = (GameObject)Instantiate(alienshot, attackOrigin.transform.position, Quaternion.identity);
			shot.transform.parent = GameObject.Find ("Minigame_SpaceInvaders(Clone)").transform;

        }

		if (GameObject.FindGameObjectsWithTag ("Gegner").Length == 0)
			won = true;

       
	}
    
    Transform RandomInvader() 
    {                 
        GameObject[] allInvaders = GameObject.FindGameObjectsWithTag("Gegner");
		if (allInvaders.Length == 0f) {
			alldead -= 1f;
			print (alldead);
			return null;
		} else {
			return allInvaders[Random.Range(0, allInvaders.Length-1)].transform;
		}
	}	
}
