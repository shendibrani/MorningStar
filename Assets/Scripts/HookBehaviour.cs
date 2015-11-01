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
    float cancelDistance = 10f;

    [SerializeField]
    float cancelSpeed = 0.5f;

    float force;

    GameObject dragObject;

    bool deathActive = false;

	bool getsDestroyed = false;
	float runOut = 0;


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
            Debug.Log("Contact Player");
            //Vector3 direction = c.transform.position - target.transform.position;
            //GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            //c.gameObject.GetComponent<RigidBodyTopDownMovement>().Push(-direction, direction.magnitude * 10);
            //GetComponent<Rigidbody>().AddForce(-direction, ForceMode.Impulse);
            //GetComponent<DealDamageOnCollision>().enabled = false;
            //GetComponent<ArrowControl>().enabled = false;
            //GetComponent<Rigidbody>().freezeRotation = true;
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            dragObject = c.gameObject;
            GetComponent<Collider>().enabled = false;
            transform.SetParent(c.transform);
            deathActive = true;
        }
		else if (c.gameObject.GetComponent<ArrowControl>())
		{
			GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
			dragObject = null;
			GetComponent<Collider>().enabled = false;
			deathActive = true;
		}
        else if (c.gameObject.GetComponent<Rigidbody>())
        {
            Debug.Log("Contact Else");
            //Vector3 direction = c.transform.position - target.transform.position;
            //c.gameObject.GetComponent<Rigidbody>().AddForce(-direction, ForceMode.Impulse);


            //GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            //GetComponent<Rigidbody>().AddForce(-direction, ForceMode.Impulse);

            GetComponent<Rigidbody>().AddForce(Vector3.forward * -arrowSpeed, ForceMode.Force);
            dragObject = c.gameObject;
            GetComponent<Collider>().enabled = false;
            transform.SetParent(c.transform);
            deathActive = true;
        }
        else
        {
			EndBrake();
            //gameObject.SetActive(false);
            //GameObject.Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (deathActive)
        {
            Vector3 direction = dragObject.transform.position - target.transform.position;
            if (dragObject.GetComponent<RigidBodyTopDownMovement>() != null){
                dragObject.GetComponent<RigidBodyTopDownMovement>().Push(-direction, direction.magnitude);
            }
            else if (dragObject.GetComponent<Rigidbody>() != null)
            {
               dragObject.GetComponent<Rigidbody>().AddForce(-direction, ForceMode.Force);
            }
            if (Vector3.Magnitude(transform.position - target.transform.position) < cancelDistance)
            {
                
				EndBrake();
                
            }
        }

		if (getsDestroyed) {
			if (Time.time > runOut + 3) {
				Debug.Log("Destroy");
				GameObject.Destroy(this.gameObject);
			}

		}
    }

	void EndBrake(){
		if (getsDestroyed == false) {
			getsDestroyed = true;
			runOut = Time.time;

			foreach (var item in gameObject.GetComponentsInChildren<ParticleSystem>()) {
				item.emissionRate = 0;
			}
		}
	}
}

