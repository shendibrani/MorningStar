using UnityEngine;
using System.Collections;

public class CameraRepositionBehaviour : MonoBehaviour {

	public GameObject a,b;
	float yPosition;

	void Start()
	{
		yPosition = transform.position.y;
	}

	void Update () 
	{
		transform.position = (b.transform.position - a.transform.position)/2 + a.transform.position;
		transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
	}
}
