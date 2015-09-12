using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuHandler : SubMenu<LookAtTransformBehaviour> {

	/* 1 = StartGame
	 * 2 = Rules/Settings
	 * 3 = Credits
	 * 4 = Exit
	 * 5 = Tutorial
	 * 6 = Scoreboard
	 * 7 = selection
	 */

	[SerializeField] bool smooth;
	[SerializeField] float smoothTime = 5f;

	[SerializeField] float radius;

	private Quaternion targetRot;

	protected override void Start()
	{
		base.Start ();
		targetRot = transform.localRotation;
		Initialise ();
	}
	
	void Update () 
	{
		if(smooth)
		{
			transform.rotation = Quaternion.Slerp (transform.localRotation, targetRot,
			                                            smoothTime * Time.deltaTime);
		}
		else
		{
			transform.rotation = targetRot;
		}
	}

	void DisposeInCircle (float radius, float startAngle)
	{
		//Debug.Log (states.Count);
		
		float startAngleRadians = startAngle * Mathf.PI / 180;
		
		float increment = Mathf.PI * 2 / states.Count;
		
		for ( int counter = 0; counter < states.Count; counter++){
			Vector3 instancePosition = new Vector3 (
				Mathf.Cos(startAngleRadians + increment * counter), 
				0 , 
				Mathf.Sin(startAngleRadians + increment * counter)
				) * radius;
			states[counter].transform.localPosition = instancePosition;
		}
	}

	public void Initialise ()
	{
		DisposeInCircle (radius, 270);
	}

	#region IStateMachine
	
	public override void NextState()
	{
		float yRot = 360f / states.Count;

		targetRot = Quaternion.Euler(targetRot.eulerAngles + new Vector3 (0f, yRot, 0f));
		state++;

		state = (state%states.Count + states.Count)%states.Count;
	}
	
	public override void PrevState()
	{
		float yRot = 360f / states.Count;
		
		targetRot = Quaternion.Euler(targetRot.eulerAngles - new Vector3 (0f, yRot, 0f));
		state--;

		state = (state%states.Count + states.Count)%states.Count;
	}
	
	public override void NextSelect(){}
	
	public override void PrevSelect(){}

	public override void Submit ()
	{
		switch(state){
		case 0 :
			overlord.SetState(1);
			break;
		case 1:
			overlord.SetState(3);
			break;
		case 2 :
			overlord.SetState(2);
			break;
		case 3 :
			Application.Quit();
			break;
		}
	}

	#endregion
}
