using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyTopDownMovement: MonoBehaviour {
	
	[SerializeField] Axis upDown;
	[SerializeField] Axis leftRight;

	[SerializeField] float baseSpeed = 200;
	[SerializeField] float _speedMultiplier = 1;

	public float speedMultiplier{
		set
		{
			_speedMultiplier = value;
		}
	}

	void Update () 
	{
		GetComponent<Rigidbody>().velocity = (new Vector3(leftRight.axisValue, GetComponent<Rigidbody>().velocity.y, upDown.axisValue)).normalized * baseSpeed * _speedMultiplier * Time.deltaTime;
	}
}