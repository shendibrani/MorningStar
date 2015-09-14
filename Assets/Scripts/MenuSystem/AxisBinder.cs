using UnityEngine;
using System.Collections;

public class AxisBinder : SubMenu<Highlightable>
{
	public AxisSelector axisSelector;
	public InvertSelector invertX, invertY;

	public PlayerControlBindingSystem owner;

	protected override void Start ()
	{
		base.Start ();
		owner = FindObjectOfType<PlayerControlBindingSystem>();
		UpdateHighlighting();
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

	public override void Submit ()
	{
		owner.passInput = false;
	}

	void UpdateHighlighting ()
	{
		foreach (Highlightable h in states){
			h.GetComponent<Highlightable>().SetHighlight(false);
		}
		
		states[state].SetHighlight(true);
	}
}

