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
    List<Image> player0ScoreList; 
    [SerializeField]
    List<Image> player1ScoreList;

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
        foreach (Image i in player0ScoreList)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 30f/255f);
        }
        foreach (Image i in player1ScoreList)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 30f/255f);
        }
        MessagingManager.AddListener(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick 1 button 7"))
        {
            if (Time.timeScale == 0) MessagingManager.Broadcast(Messages.RESUME, this.gameObject);
            else MessagingManager.Broadcast(Messages.PAUSE, this.gameObject);
        }

		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick 1 button 6"))
        {
			if (Time.timeScale == 0) 
			{
				Resume ();
				Application.LoadLevel("MainMenuTest");
			}
        }

        if ((useTimer) && (Time.time > targetTime))
        {
            if (victory0Image.enabled || victory1Image.enabled) Application.LoadLevel("MainMenuTest");
            RestartGame();
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
                    //victory0Image.Enable();
                    player0Score++;
                    //player0ScoreText.text = ""+ player0Score;
                    break;
                case 1:
                    //victory1Image.Enable();
                    player1Score++;
                    //player1ScoreText.text = "" + player1Score;
                    break;
            }
        }
        //imageTimerCallback += RestartGame;
        targetTime = Time.time + displayInterval;
        useTimer = true;

        if (player0Score == 3)
        {
            victory0Image.Enable();
            targetTime += displayInterval;
        }
        if (player1Score == 3)
        {
            victory1Image.Enable();
            targetTime += displayInterval;
        }
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

    void DisplayScore()
    {
        for (int i = 0; i < player0ScoreList.Count; i++)
        {
            Color c = player0ScoreList[i].color;
            player0ScoreList[i].color = new Color(c.r, c.g, c.b);
            //player0ScoreList[i].enabled = true;
        }
        for (int i = 0; i < player1ScoreList.Count; i++)
        {
            Color c = player1ScoreList[i].color;
            player1ScoreList[i].color = new Color(c.r, c.g, c.b);
            //player1ScoreList[i].enabled = true;
        }
    }
}