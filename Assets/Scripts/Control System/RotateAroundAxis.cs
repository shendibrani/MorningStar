using System;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
	public bool smooth;
	public float smoothTime = 5f;

	[SerializeField] Axis xAxis;
	[SerializeField] Axis zAxis;

	private Quaternion targetRot;
	
	void Start()
	{
		targetRot = transform.localRotation;
	}
	
	
	void FixedUpdate ()
	{
		if(xAxis != 0 || zAxis != 0){
			float yRot = UtilityFunctions.TrigToAngleDEG(zAxis, xAxis);
			
			targetRot = Quaternion.Euler (0f, yRot, 0f);
		}

		if(smooth)
		{
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRot,
			                                            smoothTime * Time.deltaTime);
		}
		else
		{
			transform.localRotation = targetRot;
		}
	}

}


