using UnityEngine;
using System.Collections;

public class Minigame_Jetpack_Spacetrash : MonoBehaviour {

    public GameObject navigationPrefab;
    private GameObject smallTrash;

    private RaycastHit2D screenHit;
    private GameObject Otter;
    private Vector3 movementVector;

	// Use this for initialization
	void Start () {
        Otter = transform.parent.parent.FindChild("OtterJetpack(Clone)").gameObject;
        transform.position = new Vector3(Random.Range(-32, 32), Random.Range(-32, 32), 0);
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        smallTrash = GameObject.Instantiate(navigationPrefab);
        smallTrash.transform.parent = transform.parent.parent.FindChild("Navigation").transform;
        smallTrash.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        movementVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
    }
	
	// Update is called once per frame
	void Update () {

        transform.eulerAngles += new Vector3(0, 0, 20 * Time.deltaTime);
        transform.position += movementVector * Time.deltaTime;

        screenHit = Physics2D.Raycast(transform.position, Otter.transform.position - transform.position);
        if (screenHit.distance > 3.5f)
        {
            smallTrash.SetActive(true);
            smallTrash.transform.position = screenHit.point;
            smallTrash.transform.localScale = new Vector3(0.25f - (screenHit.distance / 100) , 0.25f - (screenHit.distance / 100), 0);
            if (smallTrash.transform.localScale.x < 0) smallTrash.SetActive(false);
        }
        else smallTrash.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(smallTrash);
        Destroy(gameObject);
    }
}
