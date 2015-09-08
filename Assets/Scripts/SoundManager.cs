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

    public void playSoundFromDict (SoundEffects se)
    {
        source.clip = coupledSoundList.Find(x => x.TheSoundEffect == se).theClip;
        source.Play();
    }

}
