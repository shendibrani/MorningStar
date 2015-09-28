using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyTopDownMovement: MonoBehaviour {

	Controller controller;

	[SerializeField] float baseSpeed = 200;
	[SerializeField] float _speedMultiplier = 1;

	[SerializeField] float pushThreshold = 0.5f;

	bool pushing;

	public float speedMultiplier{
		set
		{
			_speedMultiplier = value;
		}
	}

	void Start()
	{
		controller = gameObject.GetComponentInHierarchy<PlayerInfo> ().controller;
	}

	void Update () 
	{
		if(pushing){
			if(GetComponent<Rigidbody>().velocity.magnitude < pushThreshold){
				pushing = false;
			}
		} else {
			GetComponent<Rigidbody>().velocity = (new Vector3(controller.movement.x, 0, controller.movement.y.axisValue)).normalized * baseSpeed * _speedMultiplier * Time.deltaTime + new Vector3 (0,GetComponent<Rigidbody>().velocity.y,0);
		}
	}

	public void Push(Vector3 direction, float force)
	{
		pushing = true;
		GetComponent<Rigidbody>().AddForce(direction.normalized * force, ForceMode.Impulse);
	}
}