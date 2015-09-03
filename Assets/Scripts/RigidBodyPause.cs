using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyPause : MonoBehaviour, IMessage {

    [SerializeField]
    bool isPaused = true;

    Vector3 velocity;
    Vector3 angularVelocity;
    RigidbodyConstraints constraints;
    bool useGravity;

    void Start()
    {
        MessagingManager.AddListener(this);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        velocity = rigidbody.velocity;
        angularVelocity = rigidbody.angularVelocity;
        constraints = rigidbody.constraints;
        useGravity = rigidbody.useGravity;
        if (isPaused) OnPause();
    }

    public void Message(Messages message, GameObject sender)
    {
        switch (message){
            case Messages.PAUSE:
                OnPause();
                break;
            case Messages.RESUME:
                OnResume();
                break;
        }
    }

    void OnPause()
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

    void OnResume()
    {
        GetComponent<Rigidbody>().constraints = constraints;
    }
}
