using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PitBehaviour : MonoBehaviour
{
	[SerializeField] int minSeconds, maxSeconds;

	bool state;

	float timer;

	void Update ()
	{
		if(timer < 0){
			state = !state;
			timer = RNG.NextFloat(minSeconds, maxSeconds);
			GetComponent<Animator>().SetInteger("GridState", state? 1:0);
		} else {
			timer -= Time.deltaTime;
		}
	}
}