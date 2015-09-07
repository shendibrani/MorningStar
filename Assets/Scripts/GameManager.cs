using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IMessage {

    [SerializeField]
    float displayInterval = 10f;
    [SerializeField]
    ImageController victoryImage;

    int player0Score = 0;
    int player1Score = 0;

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
        if ((useTimer) && (Time.time > targetTime))
        {
            RestartGame();
            victoryImage.Disable();
            useTimer = false;
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
            
            switch (info.playerID)
            {
                case 0:
                    victoryImage.GetComponent<Image>().color = Color.red;
                    player0Score++;
                    break;
                case 1:
                    victoryImage.GetComponent<Image>().color = Color.green;
                    player1Score++;
                    break;
            }
        }
        victoryImage.Enable();
        targetTime = Time.time + displayInterval;
        useTimer = true;
    }

    void RestartGame()
    {
        Debug.Log("reload");
        MessagingManager.Broadcast(Messages.RESTART, this.gameObject);
        //Application.LoadLevel(Application.loadedLevel);
    }
}