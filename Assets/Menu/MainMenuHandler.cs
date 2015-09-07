using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuHandler : MonoBehaviour {


	/* 1 = StartGame
	 * 2 = Rules/Settings
	 * 3 = Credits
	 * 4 = Exit
	 * 5 = Tutorial
	 * 6 = Scoreboard
	 * 7 = selection
	*/

	public int menuState {get; private set;}

//	public Animator start;
//	public Animator rules;
//	public Animator credits;
//	public Animator exit;
//	public Animator tutorial;
//	public Animator scoreboard;
//
//	public Animator arrowRight;
//	public Animator arrowLeft;

	[SerializeField] List<Transform> objects;

	[SerializeField] bool smooth;
	[SerializeField] float smoothTime = 5f;

	[SerializeField] float radius;

	private Quaternion targetRot;

	void Start()
	{
		targetRot = transform.localRotation;
		Initialise ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			float yRot = 360f / objects.Count;
			
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				targetRot = Quaternion.Euler(targetRot.eulerAngles + new Vector3 (0f, yRot, 0f));
				menuState++;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				targetRot = Quaternion.Euler(targetRot.eulerAngles - new Vector3 (0f, yRot, 0f));
				menuState--;
			}

			menuState = (menuState%objects.Count + objects.Count)%objects.Count;
		}

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

	void DisposeInCircle (float radius, float startAngle, List<Transform> objects)
	{
		Debug.Log (objects.Count);

		float circumference = radius * 2 * Mathf.PI;
		
		float startAngleRadians = startAngle * Mathf.PI / 180;
		
		float increment = Mathf.PI * 2 / objects.Count;
		
		for ( int counter = 0; counter < objects.Count; counter++){
			Vector3 instancePosition = new Vector3 (
				Mathf.Cos(startAngleRadians + increment * counter), 
				0 , 
				Mathf.Sin(startAngleRadians + increment * counter)
				) * radius;
			objects[counter].localPosition = instancePosition;
			Debug.Log(instancePosition);
			Debug.Log(objects[counter].localPosition);
		}
	}

	public void Initialise ()
	{
		DisposeInCircle (radius, 270, objects);
	}
}
