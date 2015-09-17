using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyTopDownMovement: MonoBehaviour {
	
	[SerializeField] Axis upDown;
	[SerializeField] Axis leftRight;

	[SerializeField] float baseSpeed;
	[SerializeField] float _speedMultiplier;

	public float speedMultiplier{
		set
		{
			_speedMultiplier = value;
		}
	}

	void Update () 
	{
		GetComponent<Rigidbody>().velocity = (new Vector3(leftRight.axisValue, 0, upDown.axisValue)).normalized * baseSpeed * _speedMultiplier * Time.deltaTime;
	}
}