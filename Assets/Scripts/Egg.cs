using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {

	void OnCollisionEnter(Collision other)
	{
		Object.Destroy(this.gameObject);

	}

}
