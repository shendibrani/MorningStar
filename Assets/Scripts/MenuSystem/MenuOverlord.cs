using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuOverlord : SubMenu<SubMenu> {

	/* 
	 * 0 Main Menu
	 * 1 Char Menu
	 */

	List<int> walkTable;

	void Start()
	{
		walkTable = new List<int>();

		foreach (SubMenu h in states){
			h.visible = false;
		}
		
		states[state].visible = true;
	}

	void Update () {
		switch (state){
		case 0:
			if (Input.GetKeyDown(KeyCode.LeftArrow)){
				PrevSelect();
			} else if (Input.GetKeyDown(KeyCode.RightArrow)){
				NextSelect();
			}
			break;
		case 1:
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				PrevSelect();
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				NextSelect();
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				states[state].NextSelect();
			} else if (Input.GetKeyDown(KeyCode.LeftArrow)){
				states[state].PrevSelect();
			}
			break;
		}

		if(Input.GetKeyDown(KeyCode.Return)){
			states[state].Submit();
		}
	}

	public override void SetState (int s)
	{
		walkTable.Add (state);

		states[state].OnExit();

		base.SetState (s);

		foreach (SubMenu h in states){
			h.visible = false;
		}
		states[state].visible = true;
		states[state].OnEnter();
	}

	public void Back(){
		walkTable.Remove(walkTable.Count-1);
		base.SetState (walkTable.Count-1);
		
		foreach (SubMenu h in states){
			h.visible = false;
		}
		states[state].visible = true;
	}

	public override void Submit ()
	{
		throw new System.NotImplementedException ();
	}
}
