using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    private float maxY = 7.0f;
    public float speed = 3.0f;

    void Start()
    {

    }
        // Update is called once per frame
    void FixedUpdate () {
        Vector3 newPosition = transform.position;
        newPosition.y +=  speed * Time.deltaTime;
        transform.position = newPosition;
        if (newPosition.y > maxY)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag.Contains("Gegner")) {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
           
        }

    }
}
