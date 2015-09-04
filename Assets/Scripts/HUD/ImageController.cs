using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(ImageController))]
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
        GetComponent<ImageController>().enabled = true;
    }

    public void Disable()
    {
        GetComponent<ImageController>().enabled = false;
    }

    public void FadeOut()
    {

    }

    public void FadeIt()
    {

    }
}
