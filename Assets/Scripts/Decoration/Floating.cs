using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	public float speed, delta;

	float startOffset;

	// Use this for initialization
	void Start () {
		startOffset = RNG.NextFloat();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, Mathf.Sin(startOffset+Time.time), 0) * delta * Time.deltaTime;
	}
}
