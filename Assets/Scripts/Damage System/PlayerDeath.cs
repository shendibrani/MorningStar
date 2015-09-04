using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeath
{

    [SerializeField]
    Transform weaponBase;
    GameManager gameManager;

    void Start()
    {
        //gameManager = transform.Find("Manager").GetComponent<GameManager>();
    }

    public void OnDeath()
    {
        Transform parent = transform.parent;

        foreach (Collider c in parent.GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
            if (c.GetComponent<DealDamageOnCollision>()) c.GetComponent<DealDamageOnCollision>().enabled = false;
        }

        foreach (Rigidbody r in parent.GetComponentsInChildren<Rigidbody>())
        {
            r.GetComponent<Rigidbody>().useGravity = true;
            r.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
        GetComponent<RigidBodyTopDownMovement>().enabled = false;

        MessagingManager.Broadcast(Messages.DEATH, this.transform.parent.gameObject);

        //gameManager.PlayerDeath(this.GetComponentInParent<PlayerInfo>());
    }
}
