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

    [SerializeField]
    float activeTime = 2f;

    float timer = 0;
    float offTimer = 0f;

    GameObject shield;

    // Use this for initialization
    void Start()
    {
        //List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
        //other = list.Find(x => x != this).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Execute();
        if (Time.time > offTimer)
        {
            if (shield) GameObject.Destroy(shield);
            GetComponent<ReceiveDamageOnCollision>().enabled = true;
        }
    }

    public override void Execute()
    {
        if (Time.time >= timer)
        {
            Quaternion rot = transform.rotation;
            GameObject shield = (GameObject)Instantiate(shieldObject, transform.position, Quaternion.identity);
            shield.transform.SetParent(transform);
            GetComponent<ReceiveDamageOnCollision>().enabled = false;

            timer = interval + Time.time;
            offTimer = activeTime + Time.time;
        }

    }
}
