using UnityEngine;
using System.Collections;

public class ShieldAbility : Ability {

    Transform other;
    //[SerializeField]
    //Transform spawnPoint;

    [SerializeField]
    GameObject shieldObject;

    [SerializeField]
    float interval = 6f;

    float timer = 0;


    // Use this for initialization
    void Start()
    {
        //List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
        //other = list.Find(x => x != this).transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute()
    {
        if (Time.time >= timer)
        {
            Quaternion rot = transform.rotation;
            Instantiate(shieldObject, transform.position, Quaternion.identity);
            timer = interval + Time.time;
        }

    }
}
