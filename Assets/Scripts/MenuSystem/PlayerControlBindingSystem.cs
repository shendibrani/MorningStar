using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerControlBindingSystem : SubMenu<Highlightable> {

	bool getInput;

	/* 
	 * Bindings:
	 * 0 == player 1 Movement X
	 * 1 == player 1 Movement Y
	 * 2 == player 1 Attack X
	 * 3 == player 1 Attack Y
	 * 4 == player 2 Movement X
	 * 5 == player 2 Movement Y
	 * 6 == player 2 Attack X
	 * 7 == player 2 Attack Y
	 */

	[SerializeField] AxisInversionPair[] bindings;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		UpdateHighlighting();
		PlayerInfoPasser.SetBindings(bindings);
	}

	void Update()
	{

	}

	public void SendAxes(float x, float y)
	{
//		if(getInput){
//			if (passInput){
//				if (Input.GetKeyDown(KeyCode.LeftArrow)){
//					PrevSelect();
//				} else if (Input.GetKeyDown(KeyCode.RightArrow)){
//					NextSelect();
//				}
//				if(Input.GetKeyDown(KeyCode.DownArrow)){
//					NextState();
//				} else if (Input.GetKeyDown(KeyCode.UpArrow)){
//					PrevState();
//				}
//			}else{
//				if (Input.GetKeyDown(KeyCode.LeftArrow)){
//					PrevState();
//				} else if (Input.GetKeyDown(KeyCode.RightArrow)){
//					NextState();
//				}
//				if(Input.GetKeyDown(KeyCode.DownArrow)){
//					NextSelect();
//				} else if (Input.GetKeyDown(KeyCode.UpArrow)){
//					PrevSelect();
//				}
//			}
//		}
		
		if (passInput){
			if (x <= -0.9){
				PrevSelect();
			} else if (x >= 0.9){
				NextSelect();
			}
			if(y <= -0.9){
				NextState();
			} else if (y == 1){
				PrevState();
			}
		} else {
			if (x <= -0.9){
				PrevState();
			} else if (x >= 0.9){
				NextState();
			}
			if(y <= -0.9){
				NextSelect();
			} else if (y >= 0.9){
				PrevSelect();
			}
		}
	}

	#region IStateMachine

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
