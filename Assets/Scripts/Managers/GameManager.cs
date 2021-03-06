﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IMessage
{

	[SerializeField]
	float displayInterval = 10f;
	[SerializeField]
	Image victory1Image, victory2Image;
	[SerializeField]
	List<Image> player1ScoreList, player2ScoreList;

	[SerializeField] 
	Highlightable back, resume;
	bool isResume;

	AnalogToAxisLayer LeftRight, LeftRightAlt;
	bool hasExecuted;

	bool player1Victory = false;
	bool player2Victory = false;

	int player1Score = 0;
	int player2Score = 0;

	bool isRound = false;

	float targetTime = 0f;
	bool useTimer = false;

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

		LeftRight = gameObject.AddComponent<AnalogToAxisLayer> ();
		LeftRightAlt = gameObject.AddComponent<AnalogToAxisLayer> ();

		LeftRight.axisName = PlayerInfoPasser.GetController (0).movement.x.axisName;
		LeftRightAlt.axisName = PlayerInfoPasser.GetController (1).movement.x.axisName;

		victory1Image.color = Color.clear;
		victory2Image.color = Color.clear;
		MessagingManager.AddListener(this);
	}

	// Update is called once per frame
	void Update()
	{

		if (Time.timeScale == 0) {
			if ((LeftRight <= -0.7)||(LeftRightAlt <= -0.7)||(Input.GetKeyDown(KeyCode.LeftArrow))) {
				if (!hasExecuted){
					isResume = !isResume;
					resume.SetHighlight(isResume);
					back.SetHighlight(!isResume);
					hasExecuted = true;
				}
			}
			else if ((LeftRight >= 0.7) || (LeftRightAlt >= 0.7) || (Input.GetKeyDown(KeyCode.RightArrow)))
			{
				if (!hasExecuted){
					isResume = !isResume;
					resume.SetHighlight(isResume);
					back.SetHighlight(!isResume);
					hasExecuted = true;
				}
			} else {
				hasExecuted = false;
			}
			
			if (Input.GetKeyDown(KeyCode.Return) 
			    || Input.GetKeyDown("joystick 1 button 9") 
			    || Input.GetKeyDown("joystick 2 button 9")
			    || Input.GetKeyDown("joystick 3 button 9")
			    || Input.GetKeyDown("joystick 1 button 7") 
			    || Input.GetKeyDown("joystick 2 button 7")
			    || Input.GetKeyDown("joystick 3 button 7")){
				if(isResume) {
					MessagingManager.Broadcast(Messages.RESUME, this.gameObject);
				}
				else {
					Resume();
					Application.LoadLevel("MainMenuTest");
				}
			}
		}

		else if (Input.GetKeyDown(KeyCode.P) 
		    || Input.GetKeyDown("joystick 1 button 9") 
		    || Input.GetKeyDown("joystick 2 button 9")
		    || Input.GetKeyDown("joystick 3 button 9")
		    || Input.GetKeyDown("joystick 1 button 7") 
		    || Input.GetKeyDown("joystick 2 button 7")
		    || Input.GetKeyDown("joystick 3 button 7"))
		{
			MessagingManager.Broadcast(Messages.PAUSE, this.gameObject);
			isResume = true;
			back.SetHighlight(!isResume);
			resume.SetHighlight(isResume);
		}

		if ((useTimer) && (Time.time > targetTime))
		{
            if (player1Victory || player2Victory)
            {
                Application.LoadLevel("MainMenuTest");
            }
			 RestartGame();
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
					player1Score++;
					break;
				case 1:
					player2Score++;
					break;
			}
			isRound = true;
		}
		DisplayScore();
		targetTime = Time.time + displayInterval;
		useTimer = true;

		if (player1Score == 3)
		{
			victory1Image.color = Color.white;
			player1Victory = true;
			targetTime += displayInterval;
		}
		if (player2Score == 3)
		{
			victory2Image.color = Color.white;
			player2Victory = true;
			targetTime += displayInterval;
		}
	}

	void RestartGame()
	{
		Debug.Log("reload");
		MessagingManager.Broadcast(Messages.RESTART, this.gameObject);
		isRound = false;
		victory1Image.color = Color.clear;
		victory2Image.color = Color.clear;
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
		Color c = player1ScoreList[0].color;
		if (player1Score == 1) player1ScoreList[0].color = new Color(c.r, c.g, c.b);
		if (player1Score == 2) player1ScoreList[1].color = new Color(c.r, c.g, c.b);
		if (player1Score == 3) player1ScoreList[2].color = new Color(c.r, c.g, c.b);

		c = player2ScoreList[0].color;
		if (player2Score == 1) player2ScoreList[0].color = new Color(c.r, c.g, c.b);
		if (player2Score == 2) player2ScoreList[1].color = new Color(c.r, c.g, c.b);
		if (player2Score == 3) player2ScoreList[2].color = new Color(c.r, c.g, c.b);
		//if (player1Score != 0)
		//{
		//	for (int i = 0; i < player1Score; i++)
		//	{
		//		Color c = player1ScoreList[i].color;
		//		player1ScoreList[i].color = new Color(c.r, c.g, c.b);
		//		//player0ScoreList[i].enabled = true;
		//	}
		//}
		//if (player2Score != 0)
		//{
		//	for (int i = 0; i < player2Score; i++)
		//	{
		//		Color c = player2ScoreList[i].color;
		//		player2ScoreList[i].color = new Color(c.r, c.g, c.b);
		//		//player1ScoreList[i].enabled = true;
		//	}
		//}
	}

    void OnDestroy()
    {
        MessagingManager.RemoveListener(this);
    }
}