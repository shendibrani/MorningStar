﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CoupledParticle {
    public GameObject Particle;
    public ParticleEffect TheParticleEffect;
}

public enum ParticleEffect {
    Explosion,
    Light
}

public class ParticleSys : MonoBehaviour {
    /*
    Particle system with the parameters: lifetime, position, direction, parent
    Called from anywhere.
    Bind particle prefab with name
    */
    public static ParticleSys instance = null;

    [SerializeField]
    private List<CoupledParticle> coupledParticleList;

    [SerializeField]

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
                   
    public void spawnParticle (ParticleEffect pe, Vector3 pPosition, Transform pParent, bool looping, float lifetime)
    {
        GameObject go = (GameObject)Instantiate(coupledParticleList.Find(x => x.TheParticleEffect == pe).Particle, pPosition, Quaternion.identity);
        go.GetComponent<ParticleSystem>().loop = looping;
        go.transform.parent = pParent;
        go.GetComponent<ParticleSystem>().startLifetime = lifetime;    
    }

    public void spawnParticle(ParticleEffect pe, Vector3 pPosition, Transform pParent, bool looping) {
        GameObject go = (GameObject)Instantiate(coupledParticleList.Find(x => x.TheParticleEffect == pe).Particle, pPosition, Quaternion.identity);
        go.GetComponent<ParticleSystem>().loop = looping;
        go.transform.parent = pParent;
    }

    public void spawnParticle(ParticleEffect pe, Vector3 pPosition, Transform pParent) {
        GameObject go = (GameObject)Instantiate(coupledParticleList.Find(x => x.TheParticleEffect == pe).Particle, pPosition, Quaternion.identity);
        go.transform.parent = pParent;
        
    }

    public void spawnParticle(ParticleEffect pe, Vector3 pPosition) {
        GameObject go = (GameObject)Instantiate(coupledParticleList.Find(x => x.TheParticleEffect == pe).Particle, pPosition, Quaternion.identity);

    }
}
