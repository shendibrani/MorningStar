using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterMenuManager : SubMenu<Highlightable> {

	/* 
	 * 0 = Char
	 * 1 = Weapon
	 * 2 = Ready
	 * 3 = Back
	 */

	[SerializeField] StatSelector character, weapon;

	[SerializeField] StatbarsBehaviour statbars;

    [SerializeField] int minLevelIndex = 2;
    
    [SerializeField] int maxLevelIndex = 2;

	[SerializeField] List<Sprite> characterPortraits;

	int player;

	PlayerCreationData player1, player2;

	protected override void Start () 
	{
		base.Start();
		UpdateHighlighting ();
		statbars.UpdateValues(character.currentStats + weapon.currentStats);
	}

	#region State Machine Interface

	public override void NextState ()
	{
		base.NextState ();
		UpdateHighlighting();
	}

	public override void PrevState ()
	{
		base.PrevState ();
		UpdateHighlighting();
	}

	public override void SetState (int s)
	{
		base.SetState (s);
		UpdateHighlighting();
	}

	public override void NextSelect ()
	{
		base.NextSelect ();
		statbars.UpdateValues(character.currentStats + weapon.currentStats);
	}

	public override void PrevSelect ()
	{
		base.PrevSelect ();
		statbars.UpdateValues(character.currentStats + weapon.currentStats);
	}

	#endregion

	void UpdateHighlighting ()
	{
		foreach (Highlightable h in states){
			h.GetComponent<Highlightable>().SetHighlight(false);
		}

		states[state].SetHighlight(true);
	}

	public override void OnEnter ()
	{
		player = 0;
		SetState(0);
	}

	public override void Submit ()
	{
		switch (state){
		case 2:
			if(player == 0){
				Debug.Log("Player 1 done");
				player1.characterID = character.state;
				player1.weaponID = weapon.state;
				player1.stats = character.currentStats + weapon.currentStats;
                player1.characterIcon = characterPortraits[character.state];
				weapon.SetState(0);
				character.SetState(0);
				statbars.UpdateValues(character.currentStats + weapon.currentStats);
				player = 1;
				SetState(0);
			} else if ( player == 1){
				player2.characterID = character.state;
				player2.weaponID = weapon.state;
				player2.stats = character.currentStats + weapon.currentStats;
				player2.characterIcon = characterPortraits[character.state];
				PlayerInfoPasser.PassInfo(player1, player2);
				Debug.Log(player1);
				Debug.Log(player2);
                int rnd = RNG.Next(minLevelIndex, maxLevelIndex);
				Application.LoadLevel(rnd);
			}
			break;
		case 3:
			overlord.SetState(0);
			break;
		}
	}
}