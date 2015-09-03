using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	[SerializeField] GameObject playerPrefab;

	[SerializeField] CameraRepositionBehaviour camera;

	[SerializeField] float engagementDistance;

	// Use this for initialization
	void Start () 
	{
		Debug.Log("A");
		GameObject a = (GameObject) GameObject.Instantiate(
			playerPrefab,
			new Vector3(RNG.NextFloat() * 10, 0 , RNG.NextFloat() * 10),
			Quaternion.identity);
		camera.a = a.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;
		Debug.Log("A");
		GameObject b = (GameObject) GameObject.Instantiate(
			playerPrefab, 
		    a.transform.position + (new Vector3(RNG.NextFloat(), 0 ,RNG.NextFloat()).normalized * engagementDistance),
		    Quaternion.identity);
		camera.b = b.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;
		Debug.Log("A");
	}
}
