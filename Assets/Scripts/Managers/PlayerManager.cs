﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IMessage {

	[SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject weaponPrefab;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject healthBarPrefab;

	[SerializeField] CameraRepositionBehaviour cameraReference;

	[SerializeField] float engagementDistance;

    GameObject playerA;
    GameObject playerB;
    GameObject healthA;
    GameObject healthB;

	// Use this for initialization
	void Start () 
	{
        CreatePlayers();
        MessagingManager.AddListener(this);
	}

    public void Message(Messages message, GameObject sender) {
        switch (message)
        {
            case Messages.RESTART:
                if (playerA.GetComponent<PlayerInfo>().State == PlayerInfo.PlayerState.ALIVE) Object.Destroy(playerA);
                if (playerB.GetComponent<PlayerInfo>().State == PlayerInfo.PlayerState.ALIVE) Object.Destroy(playerB);
                Object.Destroy(healthA);
                Object.Destroy(healthB);
                CreatePlayers();
                break;
        }
    }

    void CreatePlayers()
    {
        Debug.Log("A");

        //instantiate player prefab in random position from 0,0
        Vector3 pos = new Vector3(RNG.NextFloat() * 10, 0, RNG.NextFloat() * 10);
        playerA = (GameObject)GameObject.Instantiate(
            playerPrefab,
            pos,
            Quaternion.identity);
        cameraReference.a = playerA.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;
        playerA.GetComponent<PlayerInfo>().AssignPlayer(1);

        //instantiate weapon prefab
        GameObject weaponA = (GameObject)GameObject.Instantiate(weaponPrefab, pos + new Vector3(0,10,0), Quaternion.identity);
        playerA.GetComponent<PlayerInfo>().AttachWeapon(weaponA);
        
        //weaponA.GetComponent<AttachWeapon>().Attach(playerA, playerA.GetComponent<PlayerInfo>().rightRotator);

        //set up HUD 
        healthA = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthA.transform.SetParent(canvas.transform, false);
        playerA.GetComponentInChildren<ReceiveDamageOnCollision>().HealthBar = healthA.GetComponent<HealthBar>();


        Debug.Log("B");

        pos += new Vector3(RNG.NextFloat(), 0, RNG.NextFloat()).normalized * engagementDistance;
        playerB = (GameObject)GameObject.Instantiate(
            playerPrefab,
            pos,
            Quaternion.identity);
        cameraReference.b = playerB.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;
        playerB.GetComponent<PlayerInfo>().AssignPlayer(2);


        GameObject weaponB = (GameObject)GameObject.Instantiate(weaponPrefab, pos + new Vector3(0, 10, 0), Quaternion.identity);

        playerB.GetComponent<PlayerInfo>().AttachWeapon(weaponB);
        
        //weaponB.GetComponent<AttachWeapon>().Attach(playerB, playerB.GetComponent<PlayerInfo>().rightRotator);

        healthB = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthB.transform.SetParent(canvas.transform, false);
        healthB.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        playerB.GetComponentInChildren<ReceiveDamageOnCollision>().HealthBar = healthB.GetComponent<HealthBar>();

        Debug.Log("Done");
    }
}
