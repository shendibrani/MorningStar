using UnityEngine;
using System.Collections;

public class PlayerInfoPasser {

    private static PlayerInfoPasser _instance;

    public static PlayerInfoPasser instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerInfoPasser();
            }
            return _instance;
        }
    }

    static PlayerCreationData defaultData;
    static PlayerCreationData player0Data;
    static PlayerCreationData player1Data;

	static Controller[] controllers;
	static CharacterStats player0Stats;
	static CharacterStats player1Stats;

    PlayerInfoPasser()
    {
        defaultData = new PlayerCreationData();
        defaultData.characterID = 0;
        defaultData.weaponID = 0;
        player0Data = defaultData;
        player1Data = defaultData;
    }

    public static void PassInfo(PlayerCreationData pPlayer0, PlayerCreationData pPlayer1){
        player0Data = pPlayer0;
        player1Data = pPlayer1;
    }

    public static PlayerCreationData GetInfo(int PlayerID)
    {
        if (PlayerID == 0) return player0Data;
        if (PlayerID == 1) return player1Data;
        else return defaultData;
    }
	public static void SetControllers (Controller[] b)
	{
		controllers = b;
	}

	public static Controller GetController(int i)
	{
		return controllers[i];
	}
}

public struct PlayerCreationData{
    public int characterID;
    public int weaponID;
	public CharacterStats stats;
    public Sprite characterIcon;
}

