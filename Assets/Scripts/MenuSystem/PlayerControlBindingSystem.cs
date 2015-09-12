using UnityEngine;
using System.Collections;

public class PlayerControlBindingSystem : SubMenu<Highlightable> {

	public static AnalogToAxisLayer playerOneMovement;
	public static AnalogToAxisLayer playerTwoMovement;

	public static AnalogToAxisLayer playerOneAttack;
	public static AnalogToAxisLayer playerTwoAttack;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		UpdateHighlighting();
	}
	
	// Update is called once per frame
	void Update () {
		
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
	
	public override void SetState (int s)
	{
		base.SetState (s);
		UpdateHighlighting();
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
		if(state == 4){
			//update the statics and return to main menu
			overlord.SetState(0);
		}
	}
}