using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ParticleCall : MonoBehaviour
{
 
    void OnCollisionEnter(Collision col)
    {
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
}

