using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour {

	[SerializeField] Rigidbody mover;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator>().SetFloat("FrontSpeed", Vector3.Dot(mover.velocity, mover.transform.forward));
		GetComponent<Animator>().SetFloat("RightSpeed", Vector3.Dot(mover.velocity, mover.transform.right));

	}
}
