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

	protected override void Start () {
		base.Start();
		UpdateHighlighting ();
		statbars.UpdateValues(character.currentStats + weapon.currentStats);
	}

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

	void UpdateHighlighting ()
	{
		foreach (Highlightable h in states){
			h.GetComponent<Highlightable>().SetHighlight(false);
		}

		states[state].SetHighlight(true);
	}

	public override void Submit ()
	{
		switch (state){
		case 2:
			//send values to initialization, load fighting scene;
			break;
		case 3:
			overlord.SetState(0);
			break;
		}
	}
}