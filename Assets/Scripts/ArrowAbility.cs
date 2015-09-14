using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowAbility : Ability {

    Transform other;
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    GameObject arrowObject;

    [SerializeField]
    float interval = 4f;

    float timer = 0;


	// Use this for initialization
	void Start () {
        List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
        other = list.Find(x => x != this).transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Execute()
    {
        if (Time.time >= timer)
        {
            Quaternion rot = transform.rotation;
            Instantiate(arrowObject, spawnPoint.position, rot);
            timer = interval + Time.time;
        }

    }
}
