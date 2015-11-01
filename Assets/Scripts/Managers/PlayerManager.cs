using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour, IMessage 
{

	[SerializeField] List <GameObject> characterPrefabs;
    [SerializeField] List <GameObject> weaponPrefabs;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject healthBarPrefab;

	[SerializeField] CameraRepositionBehaviour cameraReference;

	[SerializeField] float engagementDistance;
    [SerializeField]
    int minSpawnDistance;
    [SerializeField]
    int maxSpawnDistance;

    PlayerCreationData player0Data;
    PlayerCreationData player1Data;

    GameObject playerA;
    GameObject playerB;
    GameObject healthA;
    GameObject healthB;

	// Use this for initialization
	void Start () 
	{
        player0Data = PlayerInfoPasser.GetInfo(0);
        player1Data = PlayerInfoPasser.GetInfo(1);

        //Debug.Log(PlayerInfoPasser.GetController(0).movement.array[0]);

        CreatePlayers();

        MessagingManager.AddListener(this);
	}

    public void Message(Messages message, GameObject sender) {
        switch (message)
        {
            case Messages.RESTART:
				player0Data = PlayerInfoPasser.GetInfo(0);
				player1Data = PlayerInfoPasser.GetInfo(1);
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

        //get info from player data
        GameObject playerPrefab = characterPrefabs[player0Data.characterID];
        GameObject weaponPrefab = weaponPrefabs[player0Data.weaponID];

        //instantiate player prefab in random position from 0,0
        Vector3 pos = new Vector3(RNG.NextFloat(-1, 2), 0, RNG.NextFloat(-1, 2)).normalized * RNG.NextFloat(minSpawnDistance, maxSpawnDistance);
        playerA = (GameObject)GameObject.Instantiate(
            playerPrefab,
            pos,
            Quaternion.identity);
        cameraReference.a = playerA.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;

		playerA.GetComponent<PlayerInfo> ().controller = PlayerInfoPasser.GetController (0);
        playerA.GetComponent<PlayerInfo>().AssignPlayer(0);

        //instantiate weapon prefab
        GameObject weaponA = (GameObject)GameObject.Instantiate(weaponPrefab, pos, Quaternion.identity);
        playerA.GetComponent<PlayerInfo>().AttachWeapon(weaponA);
        
        //weaponA.GetComponent<AttachWeapon>().Attach(playerA, playerA.GetComponent<PlayerInfo>().rightRotator);

        //set up HUD 
        healthA = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthA.transform.SetParent(canvas.transform, false);
        healthA.GetComponent<HealthBar>().SetIcon(player0Data.characterIcon);
        playerA.GetComponentInChildren<ReceiveDamageOnCollision>().healthBar = healthA.GetComponent<HealthBar>();
		playerA.GetComponentInChildren<ReceiveDamageOnCollision>().health = 100 * player0Data.stats.health;

		playerA.GetComponentInChildren<RigidBodyTopDownMovement>().speedMultiplier = 1 + player0Data.stats.speed;


        Debug.Log("B");

        playerPrefab = characterPrefabs[player1Data.characterID];
        weaponPrefab = weaponPrefabs[player1Data.weaponID];

        Vector3 posB = new Vector3(RNG.NextFloat(-1, 2), 0, RNG.NextFloat(-1, 2)).normalized * RNG.NextFloat(minSpawnDistance,maxSpawnDistance);
		while (Vector3.Magnitude(pos - posB) < 8)
		{
			posB = new Vector3(RNG.NextFloat(-1, 2), 0, RNG.NextFloat(-1, 2)).normalized * RNG.NextFloat(minSpawnDistance, maxSpawnDistance);
		}
        playerB = (GameObject)GameObject.Instantiate(
            playerPrefab,
            posB,
            Quaternion.identity);
        cameraReference.b = playerB.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;

		playerB.GetComponent<PlayerInfo> ().controller = PlayerInfoPasser.GetController (1);
        playerB.GetComponent<PlayerInfo>().AssignPlayer(1);
		
        GameObject weaponB = (GameObject)GameObject.Instantiate(weaponPrefab, posB, Quaternion.identity);
        //weaponB.transform.Rotate(0, 0, 90);
        playerB.GetComponent<PlayerInfo>().AttachWeapon(weaponB);
        
        //weaponB.GetComponent<AttachWeapon>().Attach(playerB, playerB.GetComponent<PlayerInfo>().rightRotator);

        healthB = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthB.transform.SetParent(canvas.transform, false);
        healthB.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        healthB.GetComponent<HealthBar>().SetIcon(player1Data.characterIcon);
        playerB.GetComponentInChildren<ReceiveDamageOnCollision>().healthBar = healthB.GetComponent<HealthBar>();
		playerB.GetComponentInChildren<ReceiveDamageOnCollision>().health = 100 * player1Data.stats.health;
        
		playerB.GetComponentInChildren<RigidBodyTopDownMovement>().speedMultiplier = 1 + player1Data.stats.speed;

        Debug.Log("Done");

    }

//	void SetupABindings()
//	{
//		playerA.GetComponent<PlayerInfo>().movementAxisX = PlayerInfoPasser.GetBinding(0);
//		playerA.GetComponent<PlayerInfo>().movementAxisY = PlayerInfoPasser.GetBinding(1);
//		playerA.GetComponent<PlayerInfo>().attackAxisX = PlayerInfoPasser.GetBinding(2);
//		playerA.GetComponent<PlayerInfo>().attackAxisY = PlayerInfoPasser.GetBinding(3);
//	}
//
//    void SetupBBindings()
//    {
//        playerB.GetComponent<PlayerInfo>().movementAxisX = PlayerInfoPasser.GetBinding(4);
//        playerB.GetComponent<PlayerInfo>().movementAxisY = PlayerInfoPasser.GetBinding(5);
//        playerB.GetComponent<PlayerInfo>().attackAxisX = PlayerInfoPasser.GetBinding(6);
//        playerB.GetComponent<PlayerInfo>().attackAxisY = PlayerInfoPasser.GetBinding(7);
//    }
}
