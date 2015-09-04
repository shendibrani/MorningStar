using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IMessage {

    [SerializeField]
    float displayInterval = 0.5f;
    [SerializeField]
    ImageController victoryImage;

    float targetTime = 0f;
    bool useTimer = false;

    delegate void GameEvent();
    delegate void ImageEvent();

    event ImageEvent imageTimerCallback;
    event GameEvent gameTimerCallback;

    void Start()
    {
        MessagingManager.AddListener(this);
    }
	
	// Update is called once per frame
	void Update () {
        if ((Time.time > targetTime)&&(useTimer))
        {
            gameTimerCallback();
        }
	}

    public void Message(Messages message, GameObject sender)
    { 
        switch (message){
            case Messages.DEATH:
                PlayerInfo info = sender.GetComponent<PlayerInfo>();
                PlayerDeath(info);
                break;
        }
    }

    public void PlayerDeath(PlayerInfo info)
    {
 
        if (victoryImage != null)
        {
            victoryImage.Enable();
            switch (info.playerID)
            {
                case 0:
                    victoryImage.GetComponent<Image>().color = Color.red;
                    break;
                case 1:
                    victoryImage.GetComponent<Image>().color = Color.green;
                    break;
            }
            gameTimerCallback = RestartGame;
        }

        targetTime = Time.time + displayInterval;
        useTimer = true;
    }

    void RestartGame()
    {
        Debug.Log("reload");
        Application.LoadLevel(Application.loadedLevel);
    }
}
