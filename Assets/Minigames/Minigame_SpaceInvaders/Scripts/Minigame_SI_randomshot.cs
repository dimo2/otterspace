using UnityEngine;
using System.Collections;

public class Minigame_SI_randomshot : MonoBehaviour {
	public float alldead = 1f;
    public float cooldown;
    private float dTime;
	public bool won;
	public GameObject alienshot;
    private float tF;
	// Use this for initialization
	void Start () 
    {
		won = false;
        dTime = 0f;

        tF = gameObject.GetComponentInParent<Minigame_SI_Main>().timeF;
        if (tF > 0.75f)
        {
            cooldown = 2f;
        }
        else if (tF <= 0.75f)
        {
            cooldown = 1.5f;
        }
        else if (tF <= 0.5f)
        {
            cooldown = 1f;
        }
        else if (tF <= 0.25f)
        {
            cooldown = 1f;
        }
        alldead = 1f;
        //cooldown eventuell mit Time Factor verknüpfen hier?
        cooldown *= transform.GetComponentInParent<Minigame_SI_Main>().timeF;
        
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
