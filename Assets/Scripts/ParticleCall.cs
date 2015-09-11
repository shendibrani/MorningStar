using UnityEngine;
using System.Collections;

public class ParticleCall : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Ball") {
            Debug.Log("Ball contact call");
        }

        //Sound and Particles for Ball touching Ball
        if (col.transform != this.transform && col.gameObject.name == "Ball")
        {
            for (int i = 0; i < col.contacts.Length; i++) {
                ParticleSys.instance.spawnParticle(ParticleEffect.Explosion, col.contacts[i].point, false);
                SoundManager.instance.PlaySound(SoundEffects.Hit, true);
            }
        }

		//Ball(this) touching Player
		if (col.transform != this.transform && col.gameObject.tag == "Player")
        {
            Debug.Log("touching player");
            for (int i = 0; i < col.contacts.Length; i++)
            {
                ParticleSys.instance.spawnParticle(ParticleEffect.Explosion, col.contacts[i].point, false);
                SoundManager.instance.PlaySound(SoundEffects.Hit, true);
            }
        }
    }
}
