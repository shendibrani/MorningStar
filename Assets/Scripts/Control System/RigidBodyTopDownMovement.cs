using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyTopDownMovement: MonoBehaviour {
	
	[SerializeField] Axis upDown;
	[SerializeField] Axis leftRight;
	
	[SerializeField] float speed;
	
	void Update () 
	{
		GetComponent<Rigidbody>().velocity = (new Vector3(leftRight.axisValue, 0, upDown.axisValue)).normalized * speed * Time.deltaTime;
	}
}