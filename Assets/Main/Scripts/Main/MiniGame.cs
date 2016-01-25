using UnityEngine;
using System.Collections;

public class MiniGame : MonoBehaviour 
{
	public enum State { WON, LOST, RUNNING};
	private State state;

	protected float timeFactor;

	private float score;
	public float Score
	{
		get { return score; }
		set { score = value; }
	}

	public State GetState()
	{
		return state;
	}

	public void StartGame(float tF)
	{
		state = State.RUNNING;
		score = 0;

		timeFactor = tF;
	}

	public void Destroy()
	{
		GameObject.Destroy(this.gameObject);
	}

	protected void Win()
	{
		state = State.WON;
	}

	protected void Lose()
	{
		state = State.LOST;
	}
	
}
