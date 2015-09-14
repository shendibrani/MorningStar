using UnityEngine;
using System.Collections;

public class AnimationestScript : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			anim.SetFloat ("FrontSpeed", 2f);
		}
		else
		{anim.SetFloat ("FrontSpeed", 0f);}

		if (Input.GetKey(KeyCode.DownArrow)) {
			anim.SetFloat("BackSpeed",2f);
		}
		else
		{anim.SetFloat ("BackSpeed", 0f);}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			anim.SetFloat("LeftSpeed",2f);
		}
		else
		{anim.SetFloat ("LeftSpeed", 0f);}

		if (Input.GetKey(KeyCode.RightArrow)) {
			anim.SetFloat("RightSpeed",2f);
		}
		else
		{anim.SetFloat ("RightSpeed", 0f);}
	}
}
