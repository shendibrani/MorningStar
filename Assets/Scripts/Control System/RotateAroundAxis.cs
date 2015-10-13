using System;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
	public bool smooth;
	public float smoothTime = 5f;

	public Controller controller;

	private Quaternion targetRot;
	
	void Start()
	{
        targetRot = transform.rotation;
		//controller = gameObject.GetComponentInHierarchy<PlayerInfo> ().controller;
	}
	
	
	void FixedUpdate ()
	{
		if(controller.attack.x != 0 || controller.attack.y != 0){
			float yRot = UtilityFunctions.TrigToAngleDEG(controller.attack.y, controller.attack.x);
			
			targetRot = Quaternion.Euler (0f, yRot, 0f);
		}

		if(smooth)
		{
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot,
			                                            smoothTime * Time.deltaTime);
		}
		else
		{
			transform.rotation = targetRot;
		}
	}

}


