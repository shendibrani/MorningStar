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
        OnChickenCollision(col);
    }

  
    /// <summary>
    /// Collision callback from this obj touching other weapon //morningStar Ball
    /// </summary>
    /// <param name="col"></param>
    void OnWeaponsCollide(Collision col)
    {
        if (col.transform != this.transform && col.gameObject.CompareTag("Weapon"))
        {
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Spark, col.contacts[i].point, 1f);
                SoundManager.instance.PlaySound(SoundEffects.HitWeapon);
            }
        }
    }

    /// <summary>
    /// Weapon (this) collides with Player's Body
    /// </summary>
    /// <param name="col"></param>
    void OnPlayerCollision(Collision col)
    {

        if (col.gameObject.GetComponent<ReceiveDamageOnCollision>() )
        {

            Debug.Log("Colliding with Player");
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Blood, col.contacts[i].point, 1f);
                SoundManager.instance.PlaySound(SoundEffects.HitPlayer);
            }
        }
    }

    /// <summary>
    /// Destroy on contact point
    /// </summary>
    /// <param name="col"></param>
    void OnBreakableDestroyOnPoint(Collision col) //destruct on collision Point! requires tweaking
    {

        if (col.gameObject.GetComponent<Breakable>() && col.relativeVelocity.magnitude > 10)
        {
            Debug.Log("Touching Breakable Object");
            SoundManager.instance.PlaySound(SoundEffects.HitBreakable);

            for (int i = 0; i < col.contacts.Length; i++)
            {
                newTransform = col.contacts[i].otherCollider.transform;
                newTransform.gameObject.AddComponent<Rigidbody>();
                newTransform.gameObject.AddComponent<DestroyBreakable>();
               
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

        if (col.gameObject.GetComponent<Breakable>())
        {
            Debug.Log("Touching Breakable Object");
        
          if (!col.gameObject.GetComponent<Rigidbody>().CompareTag("EggFull"))  SoundManager.instance.PlaySound(SoundEffects.HitBreakable);

            for (int i = 0; i < col.transform.childCount; i++)
            {
                newTransform = col.transform.GetChild(i);

                if (!newTransform.GetComponent<Rigidbody>())
                newTransform.gameObject.AddComponent<Rigidbody>();

                if (!newTransform.GetComponent<DestroyBreakable>())
                    newTransform.gameObject.AddComponent<DestroyBreakable>();

            }

        }
    }


    void OnChickenCollision(Collision col) {

        if (col.gameObject.CompareTag("Chicken"))
        {
            Debug.Log("Weapon hit chicken!");

            GetComponent<Rigidbody>().GetComponentInParent<AbilityButtonInput>().PickupSpecial();
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticleDestroyable(ParticleEffect.Blood, col.contacts[i].point, 1f);
                
            }
            Destroy(col.gameObject);

        }
    }

    

}