using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HookAbility : MonoBehaviour, Ability
{
	GameObject hookPrefab;

	Transform spawnPostion, target;

	float speed;

	void Start () {
		List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
		target = list.Find(x => x != this).transform;
	}

	public void Execute()
	{
		GameObject hook = Instantiate(hookPrefab, spawnPostion, Quaternion.LookRotation(target.position - spawnPostion.position));
		hook.GetComponent<Rigidbody>().velocity = hook.transform.forward * speed;
	}
}

