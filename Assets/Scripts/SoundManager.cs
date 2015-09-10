using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CoupledSound {
    public SoundEffects TheSoundEffect;
    public AudioClip theClip;
}

public class SoundManager : MonoBehaviour{

    AudioSource source;

    public static SoundManager instance = null;

    [SerializeField]
    private List<CoupledSound> coupledSoundList;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start() {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound (SoundEffects se)
    {
        source.clip = coupledSoundList.Find(x => x.TheSoundEffect == se).theClip;
        source.Play();
    }

    public void PlaySound(SoundEffects se, bool PlayOneShot)
    {
        source.clip = coupledSoundList.Find(x => x.TheSoundEffect == se).theClip;
        if (PlayOneShot)source.PlayOneShot(source.clip);
        else source.Play();
        
    }

    public void PlaySound(SoundEffects se, bool PlayOneShot, float pVolumeScale)
    {
        source.clip = coupledSoundList.Find(x => x.TheSoundEffect == se).theClip;
        if (PlayOneShot) source.PlayOneShot(source.clip, pVolumeScale);
        else source.Play();

    }

}
