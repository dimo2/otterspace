using UnityEngine;
using System.Collections;

public class MiniGame_DA_OtterUfo : MonoBehaviour { // FreezePositionX ist gecheckt, damit das Ufo nicht auf Kollisionen reagiert

    public int lives;
    private bool firstKlick;
    private Vector3 originClick;
    private Vector3 originPosition;
    private float distance;

    // Use this for initialization
    void Start () {
        lives = 3;
        firstKlick = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (firstKlick)
            {
                originClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                originPosition = transform.localPosition;
                firstKlick = false;
                return;
            }
            if (!firstKlick)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                distance = pos.y - originClick.y;
                distance *= 3;
                transform.localPosition = new Vector3(transform.localPosition.x, originPosition.y + distance, 0);
            }
        }
        if (!Input.GetMouseButton(0) && firstKlick == false) firstKlick = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Landscape"))
        {
            lives = 0;
            return;
        }

        if (col.gameObject.name.Contains("1"))
            col.gameObject.GetComponent<MiniGame_DA_AsteroidFast>().Destroy(); // Funktion zum zerstören aufrufen!
        else col.gameObject.GetComponent<MiniGame_DA_AsteroidSlow>().Destroy(); // Destroy() Funktion muss public sein!!
        //GameObject.Destroy(col.gameObject);
        lives--;
    }
}
