using UnityEngine;
using System.Collections;

public class MiniGame_DA_OtterUfo : MonoBehaviour { // FreezePositionX ist gecheckt, damit das Ufo nicht auf Kollisionen reagiert

    public int lives;
    private bool firstKlick;
    private Vector3 originClick;
    private Vector3 originPosition;
    private float distance;

    public GameObject explosionPrefab;
    private GameObject explosion;

    // Use this for initialization
    void Start () {
        lives = 3;
        firstKlick = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) // Steuerung 
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

        if (explosion != null)
        {
            explosion.transform.localScale = new Vector3(explosion.transform.localScale.x + 0.2f, explosion.transform.localScale.y + 0.2f, 1);
            explosion.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, explosion.GetComponent<SpriteRenderer>().color.a - 0.07f);
            if (explosion.transform.localScale.x > 2.5) GameObject.Destroy(explosion);
        }
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

        if (explosion != null) GameObject.Destroy(explosion);
        explosion = GameObject.Instantiate(explosionPrefab);
        explosion.transform.parent = transform.parent;
        explosion.transform.position = col.contacts[0].point; // Position gibt Welt Koordinaten, Localposition lokale.
    }
}
