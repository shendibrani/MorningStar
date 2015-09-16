using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuOverlord : SubMenu<SubMenu> {

	/* 
	 * 0 Main Menu
	 * 1 Char Menu
	 * 3 Settings Menu
	 */

	[SerializeField] Axis UpDown, LeftRight;

	[SerializeField] PlayerControlBindingSystem PCBS;

	void Start()
	{
		foreach (SubMenu h in states){
			h.visible = false;
		}
		
		states[state].visible = true;
	}

	void Update () {
		switch (state){
		case 0:
			if (LeftRight <= -0.9){
				PrevSelect();
			} else if (LeftRight >= 0.9){
				NextSelect();
			}
			break;
		case 1:
			if (UpDown >= 0.9){
				PrevSelect();
			} else if (UpDown <= -0.9){
				NextSelect();
			}
			if(LeftRight >= 0.9){
				states[state].NextSelect();
			} else if (LeftRight <= -0.9){
				states[state].PrevSelect();
			}
			break;
		case 3:
//			if (Input.GetKeyDown(KeyCode.LeftArrow)){
//				PrevSelect();
//			} else if (Input.GetKeyDown(KeyCode.RightArrow)){
//				NextSelect();
//			}
//			if(Input.GetKeyDown(KeyCode.DownArrow)){
//				states[state].NextSelect();
//			} else if (Input.GetKeyDown(KeyCode.UpArrow)){
//				states[state].PrevSelect();
//			}
			PCBS.SendAxes(LeftRight,UpDown);
			break;
		}
		if(Input.GetKeyDown("joystick 1 button 0")){
			states[state].Submit();
		}
	}

	public override void SetState (int s)
	{
		states[state].OnExit();

		base.SetState (s);

		foreach (SubMenu h in states){
			h.visible = false;
		}
		states[state].visible = true;
		states[state].OnEnter();
	}

	public override void Submit ()
	{
		throw new System.NotImplementedException ();
	}
}
