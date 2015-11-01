using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageController : MonoBehaviour {


    [SerializeField]
    float fadeTimer;
    [SerializeField]
    float displayTimer;
	bool isActivated = false;

	public bool IsActivated
	{
		get { return isActivated; }
		set { isActivated = value; }
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Enable()
    {
		GetComponent<Image>().color = Color.white;
		isActivated = true;
    }

    public void Disable()
    {
		GetComponent<Image>().color = Color.clear;
		isActivated = false;
    }

    public void FadeOut()
    {

    }

    public void FadeIt()
    {

    }
}
