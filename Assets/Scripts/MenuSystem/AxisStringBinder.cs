using UnityEngine;
using System.Collections;

public class AxisStringBinder : SubMenu<Highlightable>
{
	public string[] strings;

	protected override void Start ()
	{
		base.Start ();
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

	void UpdateHighlighting ()
	{
		foreach (Highlightable h in states){
			h.GetComponent<Highlightable>().SetHighlight(false);
		}
		
		states[state].SetHighlight(true);
	}
}

