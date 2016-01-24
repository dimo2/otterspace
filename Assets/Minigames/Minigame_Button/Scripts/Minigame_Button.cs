using UnityEngine;
using System.Collections;

public class Minigame_Button : MiniGame {

    public GameObject WinButton;
    public GameObject LoseButton;
    private GUIStyle style;
    private float time2;

    // Use this for initialization
    void Start () {
        
        GameObject lose = InstantiateRandomScale(LoseButton, 0.1f, 2f);
        lose.transform.localPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);
        GameObject win = InstantiateRandomScale(WinButton, 0.1f, 2f);
        win.transform.localPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);
        style = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainGame>().Style;



    }
	
	// Update is called once per frame
	void Update () {
        time2 += Time.deltaTime;
    }



        GameObject InstantiateRandomScale(GameObject source, float minScale,
                                  float maxScale)
    {
        GameObject clone = Instantiate(source) as GameObject;
        clone.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
       
        return clone;
    }

    public void OnGUI()
    {
        GUI.Label(
            new Rect(
            Screen.width / 2 - Screen.width / 10,
            Screen.height / 40,
            Screen.width / 5, 40),
           // "Leben übrig: " + ufoScript.lives.ToString() + '\n' +
            "Zeit bis Tod: " + Mathf.Round(15 - time2).ToString(),
            style);
    }
}
