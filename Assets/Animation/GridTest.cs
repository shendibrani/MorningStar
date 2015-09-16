using UnityEngine;
using System.Collections;

public class GridTest : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.O)) {
				anim.SetInteger("GridState",1);
			}
		if (Input.GetKey(KeyCode.C)) {
			anim.SetInteger("GridState",0);
		}
	}
}
