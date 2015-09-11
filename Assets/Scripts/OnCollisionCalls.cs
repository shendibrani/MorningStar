using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class OnCollisionCalls : MonoBehaviour
{
 
    void OnCollisionEnter(Collision col)
    {
        OnBreakableEnter(col);
        if (col.gameObject.name == "Ball")
        {
            Debug.Log("Ball contact call");
        }

        if (col.gameObject.GetComponent<ReceiveDamageOnCollision>())
        {
            OnCollidePlayer(col);
        }

        //Sound and Particles for Ball(this) touching Ball
        if (col.transform != this.transform && col.gameObject.name == "Ball")
        {
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticle(ParticleEffect.Explosion, col.contacts[i].point, false);
                SoundManager.instance.PlaySound(SoundEffects.Hit, false);
            }
        }
    }

    void OnCollidePlayer(Collision col)
    {

        Debug.Log("touching player");
        for (int i = 0; i < col.contacts.Length; i++)
        {
            ParticleSys.instance.spawnParticle(ParticleEffect.Explosion, col.contacts[i].point, false);
            SoundManager.instance.PlaySound(SoundEffects.Hit, false);
        }

    }

    void OnBreakableEnter(Collision col) {
      
        if (col.gameObject.GetComponent<Breakable>()) {
            Debug.Log("Touching Breakable Object");
            for (int i = 0; i < col.transform.childCount; i++)
            {
                Transform go = col.transform.GetChild(i);
                go.gameObject.AddComponent<Rigidbody>();
                go.gameObject.AddComponent<DestroyBreakable>();
                if (i == col.transform.childCount)
                {
                    Debug.Log("Disabled Collider");
                    col.collider.enabled = false;
                }
            }

            foreach (Rigidbody r in col.gameObject.GetComponentsInChildren<Rigidbody>())
            {
                r.useGravity = true;
                r.transform.parent = null;
            }

        }
    }

}

