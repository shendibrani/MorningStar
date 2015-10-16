using System;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
	public bool smooth;
	public float smoothTime = 5f;

    [SerializeField] 
    AnalogToAxisLayer UpDown;
    [SerializeField]
    AnalogToAxisLayer LeftRight;

	public Controller controller;

	private Quaternion targetRot;
	
	void Start()
	{
        targetRot = transform.rotation;
        foreach (AnalogToAxisLayer a in GetComponents<AnalogToAxisLayer>())
        {
            if ((a.type == StickType.ATTACK) && (a.direction == StickDirection.HORIZONTAL))
            {
                LeftRight = a;
            }
            if ((a.type == StickType.ATTACK) && (a.direction == StickDirection.VERTICAL))
            {
                UpDown = a;
            }
        }
		//controller = gameObject.GetComponentInHierarchy<PlayerInfo> ().controller;
	}
	
	
	void FixedUpdate ()
	{
		if(LeftRight.axisValue != 0 || UpDown.axisValue != 0){
			float yRot = UtilityFunctions.TrigToAngleDEG(UpDown.axisValue, LeftRight.axisValue);
			
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


