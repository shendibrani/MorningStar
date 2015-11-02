using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShockwaveAbility : Ability
{
    [SerializeField]
    float range, force;

    [SerializeField]
    float interval = 4f;

    float timer = 0;

    public GameObject particles;

    public override void Execute()
    {
        if (Time.time >= timer)
        {
            List<Rigidbody> targets = new List<Rigidbody>(FindObjectsOfType<Rigidbody>());
            targets = targets.FindAll(x =>
                                      x != GetComponent<RigidBodyTopDownMovement>() &&
                                      Vector3.Distance(transform.position, x.transform.position) <= range);

            foreach (Rigidbody target in targets)
            {
                if (target.GetComponent<RigidBodyTopDownMovement>() != null && target != GetComponent<Rigidbody>())
                {
                    target.GetComponent<RigidBodyTopDownMovement>().Push(target.transform.position - transform.position, force * 5);
                }
                else
                {
                    target.AddForce((target.transform.position - transform.position).normalized * force, ForceMode.Impulse);
                }
            }

            GameObject parts = (GameObject)GameObject.Instantiate(particles);
            parts.transform.position = this.gameObject.transform.position;
            GameObject.Destroy(parts, 2);
            timer = interval + Time.time;
        }
    }
}

