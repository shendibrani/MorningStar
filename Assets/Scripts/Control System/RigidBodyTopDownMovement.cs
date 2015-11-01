using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyTopDownMovement: MonoBehaviour {

	public Controller controller;
    [SerializeField]
    AnalogToAxisLayer UpDown;
    [SerializeField]
    AnalogToAxisLayer LeftRight;

	[SerializeField] float baseSpeed = 200;
	[SerializeField] float _speedMultiplier = 1;

	[SerializeField] float pushThreshold = 0.1f;

	bool pushing;

	public float speedMultiplier{
		set
		{
			_speedMultiplier = value;
		}
	}

	void Start()
	{
		//controller = gameObject.GetComponentInHierarchy<PlayerInfo> ().controller;
        foreach (AnalogToAxisLayer a in GetComponents<AnalogToAxisLayer>())
        {
            if ((a.type == StickType.MOVEMENT) && (a.direction == StickDirection.HORIZONTAL)){
                LeftRight = a;
            }
            if ((a.type == StickType.MOVEMENT) && (a.direction == StickDirection.VERTICAL)){
                UpDown = a;
            }
        }
	}

	void Update () 
	{
		if(pushing){
			if(GetComponent<Rigidbody>().velocity.magnitude < pushThreshold){
				pushing = false;
			}
		} else {
			GetComponent<Rigidbody>().velocity = (new Vector3(LeftRight.axisValue, 0, UpDown.axisValue)).normalized * baseSpeed * _speedMultiplier * Time.deltaTime + new Vector3 (0,GetComponent<Rigidbody>().velocity.y,0);
		}
	}

	public void Push(Vector3 direction, float force)
	{
		pushing = true;
		GetComponent<Rigidbody>().AddForce(direction.normalized * force, ForceMode.Impulse);
	}
}