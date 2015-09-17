using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeath
{

    Transform weaponBase;
    GameManager gameManager;

    void Start()
    {
        //gameManager = transform.Find("Manager").GetComponent<GameManager>();
    }

    public void AttachWeapon(GameObject o)
    {
        weaponBase = o.transform;
    }

    public void OnDeath()
    {
        Debug.Log("This");
        Transform parent = transform.parent;

        //foreach (DetonatePlayer d in GetComponentInChildren<DetonatePlayer>())
        //{
        //    d.OnDeath();
        //}

        //foreach (Collider c in parent.GetComponentsInChildren<Collider>())
        //{
            //c.enabled = true;
            //if (c.GetComponent<DealDamageOnCollision>()) c.GetComponent<DealDamageOnCollision>().enabled = false;
        //}

        //foreach (Rigidbody r in parent.GetComponentsInChildren<Rigidbody>())
        //{
            //r.GetComponent<Rigidbody>().useGravity = true;
            //r.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //}

        foreach (RotateAroundAxis r in GetComponentsInChildren<RotateAroundAxis>())
        {
            r.enabled = false;
        }

        if (weaponBase != null)
        {
            weaponBase.transform.parent = this.transform.parent;
        }
        else
        {
            Debug.LogError("Need to set weapon base for process");
        }

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponentInParent<PlayerAnimationHandler>().enabled = false;
        GetComponentInParent<Animator>().enabled = false;
        GetComponent<RigidBodyTopDownMovement>().enabled = false;
        //transform.FindChild("BodyP/HeadP").parent = transform.parent;

        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            t.parent = transform.parent;
        }

        MessagingManager.Broadcast(Messages.DEATH, this.transform.parent.gameObject);

        //gameManager.PlayerDeath(this.GetComponentInParent<PlayerInfo>());
    }
}
