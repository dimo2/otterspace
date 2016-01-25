using UnityEngine;
using System.Collections;

public class Preferences_Movement : MonoBehaviour {

	private Vector3 startPosition;
	private Quaternion startRotation;
	
	private Vector3 _Position;
	private Quaternion _Rotation;
	private Vector3 targetPosition;
	private Quaternion targetRotation;
	
	private float t; //time
	private float timeForMovement;
	
	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
		
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
			startPosition +
				new Vector3(Random.Range (-0.25f,0.25f),
				            Random.Range (-0.25f,0.25f),0);
		
		_Position = transform.position;
		_Rotation = transform.rotation;
		t = 0;
	}
}
