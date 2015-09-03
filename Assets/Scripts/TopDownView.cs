using UnityEngine;
using System.Collections;

public class TopDownView : MonoBehaviour {
    //Declare target to view
    public GameObject target;
    //Declare desire position of camera
    public Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        this.transform.position = new Vector3(target.transform.position.x + cameraPosition.x, target.transform.position.y + cameraPosition.y + 15, target.transform.position.z + cameraPosition.z - 3);
        this.transform.LookAt(target.transform);
    }
}
