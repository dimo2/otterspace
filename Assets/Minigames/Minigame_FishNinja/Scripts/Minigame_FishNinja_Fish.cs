using UnityEngine;
using System.Collections;

public class Minigame_FishNinja_Fish : MonoBehaviour {

	private Vector3 startPosition;
	private Quaternion startRotation;
	
	private Vector3 _Position;
	private Quaternion _Rotation;
	private Vector3 targetPosition;
	private Quaternion targetRotation;
	
	private float t; //time
	private float timeForMovement;

	public int score;
	public Sprite[] sprites;
	private int index;
	private float speed;
	// private GameObject fishNinja;
	
	// Use this for initialization
	void Start () 
	{

		Minigame_FishNinja fishNinja = transform.GetComponentInParent<Minigame_FishNinja> ();
		speed = 10.0f * (1+(1-fishNinja.tF));


		index = Random.Range (0, 3);
		startPosition = transform.position = new Vector3 (Random.Range (-7.0f, 7f), -6.3f, 0);
		startRotation = transform.rotation;
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites [index];
		CalcValues();
	}
	
	// Update is called once per frame
	void Update ()
	{
		t += Time.deltaTime;


		if (t > timeForMovement)
			CalcValues();
		else
		{
			float currentAngle = targetRotation.eulerAngles.z;
			transform.rotation = 
				Quaternion.Slerp(_Rotation, targetRotation, (t/timeForMovement));
			transform.position =
				Vector3.Lerp(_Position, targetPosition, (t/timeForMovement));
		}


	}
	
	private void CalcValues()
	{
		timeForMovement = 
			Random.Range (1.5f, 3.0f);
		
		targetRotation = 
			new Quaternion(startRotation.x,
			               startRotation.y, 
			               Random.Range (-0.1f,0.1f),
			               startRotation.w);
		targetPosition = 
			transform.position +
			new Vector3 (Random.Range (-0.25f, 0.25f),
				             Random.Range (-0.25f, 0.25f) + speed, 0);
		
		_Position = transform.position;
		_Rotation = transform.rotation;
		t = 0;
	}

	private void OnMouseDown() {
		score++;
		Destroy (gameObject);
	}

}
