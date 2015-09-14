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
        OnWeaponsCollide(col);
        OnPlayerCollision(col);
      
    }
    
    /// <summary>
    /// Collision callback from this obj touching other weapon //morningStar Ball
    /// </summary>
    /// <param name="col"></param>
    void OnWeaponsCollide(Collision col)
    {
        if (col.transform != this.transform && col.gameObject.name == "Ball")
        {
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Spark, col.contacts[i].point, 1f);
                SoundManager.instance.PlaySound(SoundEffects.Hit, false);
            }
        }
    }

    /// <summary>
    /// Weapon (this) colliders with Player's Body
    /// </summary>
    /// <param name="col"></param>
    void OnPlayerCollision(Collision col)
    {

        if (col.gameObject.GetComponent<ReceiveDamageOnCollision>() && col.relativeVelocity.magnitude > 2)
        {

            Debug.Log("Colliding with Player");
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Blood, col.contacts[i].point, 1f);
                SoundManager.instance.PlaySound(SoundEffects.Hit, false);
            }
        }
    }

    /// <summary>
    /// Destroy on contact point
    /// </summary>
    /// <param name="col"></param>
    void OnBreakableDestroyOnPoint(Collision col) //destruct on collision Point! requires tweaking
    {

        if (col.gameObject.GetComponent<Breakable>() && col.relativeVelocity.magnitude > 2)
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

    /// <summary>
    /// Destroy all sub-pieces at colliding touch
    /// </summary>
    /// <param name="collider"></param>
    void OnBreakableDestroyAll(Collision col)
    { //Destruct all at once! 

        if (col.gameObject.GetComponent<Breakable>() && col.relativeVelocity.magnitude > 2)
        {
            Debug.Log("Touching Breakable Object");
            SoundManager.instance.PlaySound(SoundEffects.Hit);

            for (int i = 0; i < col.transform.childCount; i++)
            {
                newTransform = col.transform.GetChild(i);
                if (!newTransform.GetComponent<Rigidbody>())
                newTransform.gameObject.AddComponent<Rigidbody>();
                if (!newTransform.GetComponent<DestroyBreakable>())
                    newTransform.gameObject.AddComponent<DestroyBreakable>();

                //newTransform.gameObject.GetComponent<Rigidbody>().useGravity = true;
                //newTransform.gameObject.transform.parent = null;
                
            }

            //foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            //{
            //    rb.useGravity = true;
            //    rb.transform.parent = null;
            //}
        }
    }

    

}

