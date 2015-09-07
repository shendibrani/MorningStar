using System;
using UnityEngine;

public abstract class Highlightable : MonoBehaviour
{
	[SerializeField] protected bool highlighted;
	[SerializeField] protected bool reactToMouseOver;
	[SerializeField] protected bool reactToMouseClick;

	protected virtual void Start(){
		ProcessHighlight();
	}

	public void ToggleHighlight()
	{
		highlighted = !highlighted;
		ProcessHighlight();
	}
	
	public void SetHighlight(bool b) 
	{
		highlighted = b;
		ProcessHighlight();
	}

	public abstract void ProcessHighlight();
}


