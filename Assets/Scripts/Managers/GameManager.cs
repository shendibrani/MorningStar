using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IMessage {

    [SerializeField]
    float displayInterval = 10f;
    [SerializeField]
    ImageController victory0Image;
    [SerializeField]
    ImageController victory1Image;
    [SerializeField]
    Text player0ScoreText;
    [SerializeField]
    Text player1ScoreText;

    int player0Score = 0;
    int player1Score = 0;

    float targetTime = 0f;
    bool useTimer = false;

    delegate void GameEvent();
    delegate void ImageEvent();

    event ImageEvent imageTimerCallback;
    event GameEvent gameTimerCallback;

    float timeScale;

    void Start()
    {
        player0ScoreText.text = "" + player0Score;
        player1ScoreText.text = "" + player1Score;
        MessagingManager.AddListener(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0) MessagingManager.Broadcast(Messages.RESUME, this.gameObject);
            else MessagingManager.Broadcast(Messages.PAUSE, this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("MainMenuTest");
        }

        if ((useTimer) && (Time.time > targetTime))
        {
            RestartGame();
            //if (gameTimerCallback != null) gameTimerCallback();
            //gameTimerCallback -= RestartGame;
        }
	}

    public void Message(Messages message, GameObject sender)
    { 
        switch (message){
            case Messages.DEATH:
                PlayerInfo info = sender.GetComponent<PlayerInfo>();
                PlayerDeath(info);
                break;
            case Messages.PAUSE:
                Pause();
                break;
            case Messages.RESUME:
                Resume();
                break;

        }
    }

    public void PlayerDeath(PlayerInfo info)
    {
 
        if (victory0Image != null)
        {
            
            switch (info.playerID)
            {
                case 0:
                    victory0Image.Enable();
                    player0Score++;
                    player0ScoreText.text = ""+ player0Score;
                    break;
                case 1:
                    victory1Image.Enable();
                    player1Score++;
                    player1ScoreText.text = "" + player1Score;
                    break;
            }
        }
        //imageTimerCallback += RestartGame;
        targetTime = Time.time + displayInterval;
        useTimer = true;
    }

    void RestartGame()
    {
        Debug.Log("reload");
        MessagingManager.Broadcast(Messages.RESTART, this.gameObject);
        victory0Image.Disable();
        victory1Image.Disable();
        useTimer = false;
        //Application.LoadLevel(Application.loadedLevel);
    }

    void Pause()
    {
        timeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    void Resume()
    {
        Time.timeScale = timeScale;
    }
}