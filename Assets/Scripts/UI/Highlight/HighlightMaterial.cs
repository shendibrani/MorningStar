using UnityEngine;
using System.Collections;

public class HighlightMaterial : Highlightable 
{
	[SerializeField] Material material;
	[SerializeField] Color startingColor;
	[SerializeField] Color highlightColor;

	// Use this for initialization
	protected override void Start () 
	{
		material = GetComponent<Renderer>().material;
		startingColor = material.color;
		base.Start();
	}
	
	void OnMouseEnter()
	{
		if(reactToMouseOver){
			SetHighlight(true);
		}
	}

	void OnMouseExit()
	{
		if(reactToMouseOver){
			SetHighlight(false);
		}
	}

	void OnMouseOver()
	{
		if(reactToMouseClick){
			if(Input.GetMouseButtonUp(0)){
				ToggleHighlight();
			}
		}
	}

	public override void ProcessHighlight ()
	{
		if(highlighted){
			material.color = highlightColor;
		}
		else {
			material.color = startingColor;
		}
	}
}
