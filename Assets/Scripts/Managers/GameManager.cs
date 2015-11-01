using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IMessage
{

	[SerializeField]
	float displayInterval = 10f;
	[SerializeField]
	ImageController victory1Image;
	[SerializeField]
	ImageController victory2Image;
	[SerializeField]
	List<Image> player1ScoreList;
	[SerializeField]
	List<Image> player2ScoreList;

	int player1Score = 0;
	int player2Score = 0;

	bool isRound = false;

	float targetTime = 0f;
	bool useTimer = false;

	delegate void GameEvent();
	delegate void ImageEvent();

	event ImageEvent imageTimerCallback;
	event GameEvent gameTimerCallback;

	float timeScale;

	void Start()
	{
		foreach (Image i in player1ScoreList)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, 30f / 255f);
		}
		foreach (Image i in player2ScoreList)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, 30f / 255f);
		}
		MessagingManager.AddListener(this);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick 1 button 9"))
		{
			if (Time.timeScale == 0) MessagingManager.Broadcast(Messages.RESUME, this.gameObject);
			else MessagingManager.Broadcast(Messages.PAUSE, this.gameObject);
		}

		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick 1 button 8"))
		{
			if (Time.timeScale == 0)
			{
				Resume();
				Application.LoadLevel("MainMenuTest");
			}
		}

		if ((useTimer) && (Time.time > targetTime))
		{
			if (victory1Image.IsActivated || victory2Image.IsActivated) Application.LoadLevel("MainMenuTest");
			else { RestartGame(); }
			//gameTimerCallback -= RestartGame;
		}
	}

	public void Message(Messages message, GameObject sender)
	{
		switch (message)
		{
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

	void PlayerDeath(PlayerInfo info)
	{
		if (!isRound)
		{
			switch (info.playerID)
			{
				case 0:
					//victory0Image.Enable();
					player1Score++;
					//player0ScoreText.text = ""+ player0Score;
					break;
				case 1:
					//victory1Image.Enable();
					player2Score++;
					//player1ScoreText.text = "" + player1Score;
					break;
			}
			isRound = true;
		}
		DisplayScore();
		targetTime = Time.time + displayInterval;
		useTimer = true;

		if (player1Score == 3)
		{
			victory1Image.Enable();
			targetTime += displayInterval;
		}
		if (player2Score == 3)
		{
			victory2Image.Enable();
			targetTime += displayInterval;
		}
	}

	void RestartGame()
	{
		Debug.Log("reload");
		MessagingManager.Broadcast(Messages.RESTART, this.gameObject);
		isRound = false;
		victory1Image.Disable();
		victory2Image.Disable();
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
		for (int i = 0; i < player1Score; i++)
		{
			Color c = player1ScoreList[i].color;
			player1ScoreList[i].color = new Color(c.r, c.g, c.b);
			//player0ScoreList[i].enabled = true;
		}
		for (int i = 0; i < player2Score; i++)
		{
			Color c = player2ScoreList[i].color;
			player2ScoreList[i].color = new Color(c.r, c.g, c.b);
			//player1ScoreList[i].enabled = true;
		}
	}
}