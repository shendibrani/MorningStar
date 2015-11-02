using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBoom : Ability {

    [SerializeField]
	GameObject BoomerangPrefab;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    float interval = 4f;

    float timer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public override void Execute()
    {
        if ((Time.time >= timer) && BoomerangPrefab != null)
        {
            GameObject boomerang = (GameObject)Instantiate(BoomerangPrefab, spawnPoint.position, transform.rotation);
            BoomerangBase script = boomerang.GetComponent<BoomerangBase>();

            List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
            Transform target = list.Find(x => x != this.GetComponent<LookAtEachotherBehaviour>()).transform;

            script.SetTargets(this.transform, target);
        }
    }
}
