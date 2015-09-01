using UnityEngine;
using System.Collections;

public class BasicTopDownMovement : MonoBehaviour {

	[SerializeField] Axis upDown;
	[SerializeField] Axis leftRight;

	[SerializeField] float speed;
	
	void Update () 
	{
		transform.position += (new Vector3(leftRight.axisValue, 0, upDown.axisValue)).normalized * speed * Time.deltaTime;
	}
}
