using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour {

	[SerializeField] Rigidbody mover;
    public AudioClip footSteps;
    AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator>().SetFloat("FrontSpeed", Vector3.Dot(mover.velocity, mover.transform.forward));
		GetComponent<Animator>().SetFloat("RightSpeed", Vector3.Dot(mover.velocity, mover.transform.right));

        if (GetComponent<Animator>().IsInTransition(0) && !source.isPlaying)
        {
            source.clip = footSteps;
            source.loop = true;
            source.time = 0.15f;
            if (source.time == 0.25f) source.time = 0.70f;

            source.Play();
        }
        else if (mover.velocity.magnitude < 1)
        {
            source.Pause();
           
        }

	}
}
