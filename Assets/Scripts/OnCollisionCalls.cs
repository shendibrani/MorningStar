using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OnCollisionCalls : MonoBehaviour
{
   
    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

    Transform newTransform;

    void OnCollisionEnter(Collision col)
    {
        OnBreakableDestroyAll(col);

        if (col.gameObject.GetComponent<ReceiveDamageOnCollision>())
        {
            OnCollidePlayer(col);
        }

        //Sound and Particles for Ball(this) touching Ball
        if (col.transform != this.transform && col.gameObject.name == "Ball")
        {
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Spark, col.contacts[i].point, 1f);
                SoundManager.instance.PlaySound(SoundEffects.Hit, false);
            }
        }
    }

    void OnCollidePlayer(Collision col)
    {

        Debug.Log("Colliding with Player");
        for (int i = 0; i < col.contacts.Length; i++)
        {
            ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Blood, col.contacts[i].point, 1f);
            SoundManager.instance.PlaySound(SoundEffects.Hit, false);
        }

    }

    void OnBreakableDestroyOnPoint(Collision col) //destruct on collision Point! requires tweaking
    {

        if (col.gameObject.GetComponent<Breakable>() && rb.velocity.magnitude > 3f )
        {
            Debug.Log("Touching Breakable Object");
            SoundManager.instance.PlaySound(SoundEffects.Hit);

            for (int i = 0; i < col.contacts.Length; i++)
            {
                newTransform = col.contacts[i].otherCollider.transform;
                newTransform.gameObject.AddComponent<Rigidbody>();
                newTransform.gameObject.AddComponent<DestroyBreakable>();
                //tweak somehow to check for structural integrity
                col.contacts[i].otherCollider.transform.parent = null; 

            }

        }
    }

    void OnBreakableDestroyAll(Collision col) { //Destruct all at once! 
      
        if (col.gameObject.GetComponent<Breakable>() ) {
            Debug.Log("Touching Breakable Object");
            SoundManager.instance.PlaySound(SoundEffects.Hit);

            for (int i = 0; i < col.transform.childCount; i++)
            {
                newTransform = col.transform.GetChild(i);
                newTransform.gameObject.AddComponent<Rigidbody>();
                newTransform.gameObject.AddComponent<DestroyBreakable>();
                
            }

            foreach (Rigidbody r in col.gameObject.GetComponentsInChildren<Rigidbody>())
            {
                r.useGravity = true;
                r.transform.parent = null;
            }

        }
    }

}

