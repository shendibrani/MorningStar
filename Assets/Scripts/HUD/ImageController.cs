using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageController : MonoBehaviour {

	bool isActivated = false;

	public bool IsActivated
	{
		get { return isActivated; }
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Visible()
    {
		GetComponent<Image>().color = Color.white;
		isActivated = true;
    }

    public void Invisible()
    {
		GetComponent<Image>().color = Color.clear;
		isActivated = false;
    }
}
