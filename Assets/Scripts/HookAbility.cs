using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HookAbility : MonoBehaviour, Ability
{
	GameObject hookPrefab;

	float speed;

    Transform target;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject arrowObject;

    [SerializeField]
    float interval = 4f;

    float timer = 0;

	void Start () {
		List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
		target = list.Find(x => x != this).transform;
	}

	public void Execute()
	{
        if (Time.time >= timer)
        {
            Quaternion rot = transform.rotation;
            GameObject hook = (GameObject)Instantiate(hookPrefab, spawnPoint.position, rot);
            hook.GetComponent<HookBehaviour>().SetTarget(this.transform);
            timer = interval + Time.time;
        }
		//GameObject hook = Instantiate(hookPrefab, spawnPostion, Quaternion.LookRotation(target.position - spawnPostion.position));
		//hook.GetComponent<Rigidbody>().velocity = hook.transform.forward * speed;
	}
}

