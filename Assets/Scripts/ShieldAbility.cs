using UnityEngine;
using System.Collections;

public class ShieldAbility : Ability
{

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
    bool isActive = false;

    // Use this for initialization
    void Start()
    {
        //List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
        //other = list.Find(x => x != this).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > offTimer)
        {
            isActive = false;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.GetComponent<DealDamageOnCollision>() != null)
        {
            if (isActive)
            {
                GetComponent<ReceiveDamageOnCollision>().RecieveDamage(-c.collider.GetComponent<DealDamageOnCollision>().damage);
                if (GetComponent<ReceiveDamageOnCollision>().health > GetComponent<ReceiveDamageOnCollision>().maxHealth)
                {
                    GetComponent<ReceiveDamageOnCollision>().RecieveDamage(GetComponent<ReceiveDamageOnCollision>().health - GetComponent<ReceiveDamageOnCollision>().maxHealth);
                }
            }
        }
    }

    public override void Execute()
    {
        if (Time.time >= timer)
        {
            Quaternion rot = transform.rotation;
            Vector3 pos = transform.position + new Vector3(0, 1, 0);
            shield = (GameObject)GameObject.Instantiate(shieldObject, pos, Quaternion.identity);
            shield.transform.SetParent(transform);
            isActive = true;
            timer = interval + Time.time;
            offTimer = activeTime + Time.time;
            shield.GetComponent<ShieldDecay>().SetTimer(offTimer);
        }
    }
}
