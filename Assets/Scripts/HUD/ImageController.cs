using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageController : MonoBehaviour {


    [SerializeField]
    float fadeTimer;
    [SerializeField]
    float displayTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Enable()
    {
        GetComponent<Image>().enabled = true;
    }

    public void Disable()
    {
        GetComponent<Image>().enabled = false;
    }

    public void FadeOut()
    {

    }

    public void FadeIt()
    {

    }
}
