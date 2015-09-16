using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LookAtEachotherBehaviour : MonoBehaviour {

	Transform other;

	// Use this for initialization
	void Start () 
	{
		List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
		other = list.Find(x => x != this).transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(other);
	}
}
