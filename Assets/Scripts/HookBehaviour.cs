using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class HookBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float arrowSpeed = 600f;

    [SerializeField]
    float cancelDistance = 4f;

    float force;

    bool deathActive = false;

	// Use this for initialization
	void Start ()
	{
        GetComponent<Rigidbody>().AddForce(transform.forward * arrowSpeed, ForceMode.Force);
	}

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<RigidBodyTopDownMovement>())
        {
            Vector3 direction = c.transform.position - target.transform.position;
            GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            c.gameObject.GetComponent<RigidBodyTopDownMovement>().Push(direction, direction.magnitude);
            //GetComponent<DealDamageOnCollision>().enabled = false;
            //GetComponent<ArrowControl>().enabled = false;
            //GetComponent<Rigidbody>().freezeRotation = true;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Collider>().enabled = false;
            transform.SetParent(c.transform);
            deathActive = true;
        }
        else if (c.gameObject.GetComponent<Rigidbody>())
        {
            c.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * -arrowSpeed, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            GetComponent<Collider>().enabled = false;
            transform.SetParent(c.transform);
            deathActive = true;
        }
        else
        {
            //gameObject.SetActive(false);
            GameObject.Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (deathActive)
        {
            if ((Vector3.Magnitude(transform.position - target.transform.position) < cancelDistance)) GameObject.Destroy(this.gameObject);
        }
    }
}

