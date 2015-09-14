using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerControlBindingSystem : SubMenu<Highlightable> {

	bool getInput;

	[SerializeField] AxisInversionPair[] bindings;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		UpdateHighlighting();
	}

	void Update()
	{
		if(getInput){
			if (passInput){
				if (Input.GetKeyDown(KeyCode.LeftArrow)){
					PrevSelect();
				} else if (Input.GetKeyDown(KeyCode.RightArrow)){
					NextSelect();
				}
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					NextState();
				} else if (Input.GetKeyDown(KeyCode.UpArrow)){
					PrevState();
				}
			}else{
				if (Input.GetKeyDown(KeyCode.LeftArrow)){
					PrevState();
				} else if (Input.GetKeyDown(KeyCode.RightArrow)){
					NextState();
				}
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					NextSelect();
				} else if (Input.GetKeyDown(KeyCode.UpArrow)){
					PrevSelect();
				}
			}
		}
	}
	
	#region IStateMachine

	public override void OnEnter ()
	{
		getInput = true;
	}

	public override void OnExit ()
	{
		getInput = false;
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
		if(state == 4){
			bindings = new AxisInversionPair[8];
			for(int counter = 0; counter < 4; counter++){
				bindings[counter].axisName = states[counter].GetComponent<AxisBinder>().axisSelector.xAxis;
				bindings[counter].invert = states[counter].GetComponent<AxisBinder>().invertX;
				
				bindings[counter+1].axisName = states[counter].GetComponent<AxisBinder>().axisSelector.yAxis;
				bindings[counter+1].invert = states[counter].GetComponent<AxisBinder>().invertY;
			}
			overlord.SetState(0);
		} else if (!passInput){
			passInput = true;
		} else {
			base.Submit();
		}
	}

	#endregion

	void UpdateHighlighting ()
	{
		foreach (Highlightable h in states){
			h.GetComponent<Highlightable>().SetHighlight(false);
		}
		
		states[state].SetHighlight(true);
	}
}

[System.Serializable]
public struct AxisInversionPair{
	public string axisName;
	public bool invert;
}
