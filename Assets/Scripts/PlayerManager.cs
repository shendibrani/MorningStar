using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	[SerializeField] GameObject playerPrefab;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject healthBarPrefab;

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

        GameObject healthA = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthA.transform.SetParent(canvas.transform, false);
        a.GetComponentInChildren<ReceiveDamageOnCollision>().HealthBar = healthA.GetComponent<HealthBar>();

		Debug.Log("A");
		GameObject b = (GameObject) GameObject.Instantiate(
			playerPrefab, 
		    a.transform.position + (new Vector3(RNG.NextFloat(), 0 ,RNG.NextFloat()).normalized * engagementDistance),
		    Quaternion.identity);
		camera.b = b.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;

        GameObject healthB = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthB.transform.SetParent(canvas.transform, false);
        healthB.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        b.GetComponentInChildren<ReceiveDamageOnCollision>().HealthBar = healthB.GetComponent<HealthBar>();

		Debug.Log("A");
	}
}
