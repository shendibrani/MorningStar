using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    static LoadingScreen _instance;
    public Texture2D screen;

    public static LoadingScreen instance
    {
        get
        {
            if (_instance == null) _instance = new LoadingScreen();
            return _instance;
        }
    }

    LoadingScreen()
    {

    }

    public static void Load(int index)
    {
        if (CheckInstance()) return;
        //instance.guiTexture.enabled = true;
        Application.LoadLevel(index);
        //instance.guiTexture.enabled = false;
    }

    public static void Load(string name)
    {
        if (CheckInstance()) return;
        //instance.guiTexture.enabled = true;
        Application.LoadLevel(name);
        //instance.guiTexture.enabled = false;
    }

    static bool CheckInstance()
    {
        if (instance == null)
            Debug.LogError("Loading Screen is not existing in scene.");
        return instance;
    }
}
