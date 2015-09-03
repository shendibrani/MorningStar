using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyPause : MonoBehaviour, IPausable {

    [SerializeField]
    bool isPaused = true;

    Vector3 velocity;
    Vector3 angularVelocity;
    RigidbodyConstraints constraints;
    bool useGravity;

    void Start()
    {

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        velocity = rigidbody.velocity;
        angularVelocity = rigidbody.angularVelocity;
        constraints = rigidbody.constraints;
        useGravity = rigidbody.useGravity;
        if (isPaused) OnPause();
    }

    public void OnPause()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        velocity = rigidbody.velocity;
        angularVelocity = rigidbody.angularVelocity;
        constraints = rigidbody.constraints;
        useGravity = rigidbody.useGravity;

        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //rigidbody.velocity = Vector3.zero();
        //rigidbody.angularVelocity = Vector3.
    }

    public void OnResume()
    {
        GetComponent<Rigidbody>().constraints = constraints;
    }
}
