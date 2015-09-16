using UnityEngine;
using System.Collections;

public class PitKillZone : MonoBehaviour {


    void OnTriggerEnter(Collider c)
    {
        if (c.GetComponent<ReceiveDamageOnCollision>() != null)
        {
            c.GetComponent<ReceiveDamageOnCollision>().RecieveDamage(GetComponent<DealDamageOnCollision>().damage);
            c.GetComponent<ReceiveDamageOnCollision>().CheckDeath();
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.GetComponent<ReceiveDamageOnCollision>() != null)
        {
            c.GetComponent<ReceiveDamageOnCollision>().RecieveDamage(GetComponent<DealDamageOnCollision>().damage);
            c.GetComponent<ReceiveDamageOnCollision>().CheckDeath();
        }
    }
}
