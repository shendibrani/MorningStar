using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class CoupledSound {
    public SoundEffects TheSoundEffect;
    public AudioClip[] PlayClips;
}

public class SoundManager : MonoBehaviour{

    private AudioSource source;
  
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
        AudioClip[] clipArray = coupledSoundList.Find(x => x.TheSoundEffect == se).PlayClips;
        int index = RNG.Next(0, clipArray.Length);
        source.clip = clipArray[index];
        source.Play();
    }

    
    public void PlaySound(SoundEffects se, bool PlayOneShot)
    {
        AudioClip[] clipArray = coupledSoundList.Find(x => x.TheSoundEffect == se).PlayClips;
        int index = RNG.Next(0, clipArray.Length);
        source.clip = clipArray[index];
        

        if (PlayOneShot)source.PlayOneShot(source.clip);
        else source.Play();
        
    }

    public void PlaySound(SoundEffects se, bool PlayOneShot, float pVolumeScale)
    {
        AudioClip[] clipArray = coupledSoundList.Find(x => x.TheSoundEffect == se).PlayClips;
        int index = RNG.Next(0, clipArray.Length);
        source.clip = clipArray[index];


        if (PlayOneShot) source.PlayOneShot(source.clip, pVolumeScale);
        else source.Play();

    }

}
