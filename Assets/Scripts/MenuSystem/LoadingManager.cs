using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	//void Update () {
//	
	//}

    void OnLevelWasLoaded(int level)
    {

        Application.LoadLevelAdditive(1);
    }
}
