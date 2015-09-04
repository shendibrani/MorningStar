using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour, IMessage {

	[SerializeField] GameObject playerPrefab;

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
        playerA = (GameObject)GameObject.Instantiate(
            playerPrefab,
            new Vector3(RNG.NextFloat() * 10, 0, RNG.NextFloat() * 10),
            Quaternion.identity);
        cameraReference.a = playerA.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;

        healthA = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthA.transform.SetParent(canvas.transform, false);
        playerA.GetComponentInChildren<ReceiveDamageOnCollision>().HealthBar = healthA.GetComponent<HealthBar>();

        Debug.Log("A");
        playerB = (GameObject)GameObject.Instantiate(
            playerPrefab,
            playerA.transform.position + (new Vector3(RNG.NextFloat(), 0, RNG.NextFloat()).normalized * engagementDistance),
            Quaternion.identity);
        cameraReference.b = playerB.GetComponentInChildren<RigidBodyTopDownMovement>().gameObject;

        healthB = (GameObject)GameObject.Instantiate(healthBarPrefab, new Vector3(960, -768, 0), Quaternion.identity);
        healthB.transform.SetParent(canvas.transform, false);
        healthB.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
        playerB.GetComponentInChildren<ReceiveDamageOnCollision>().HealthBar = healthB.GetComponent<HealthBar>();

        Debug.Log("A");
    }
}
