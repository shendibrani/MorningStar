using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeath
{

    [SerializeField]
    Transform weaponBase;

    public void OnDeath()
    {
        Transform parent = transform.parent;

        foreach (Collider c in parent.GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }

        foreach (Rigidbody r in parent.GetComponentsInChildren<Rigidbody>())
        {
            weaponBase.GetComponent<Rigidbody>().useGravity = true;
            weaponBase.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
    }
}
