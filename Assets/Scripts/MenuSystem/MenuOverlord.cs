﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuOverlord : SubMenu<SubMenu>
{

    /* 
     * 0 Main Menu
     * 1 Char Menu
     * 3 Settings Menu
     */

    [SerializeField]
    Axis UpDown, UpDownAlt, LeftRight, LeftRightAlt;

    [SerializeField]
    PlayerControlBindingSystem PCBS;

    bool hasExecuted = false;

    void Start()
    {
        foreach (SubMenu h in states)
        {
            h.visible = false;
        }

        states[state].visible = true;
    }

    void Update()
    {
        switch (state) {
		case 0:
			if ((LeftRight <= -0.7)||(LeftRightAlt <= -0.7)||(Input.GetKeyDown(KeyCode.LeftArrow))) {
				if (!hasExecuted)
					PrevSelect ();
				hasExecuted = true;
            }
            else if ((LeftRight >= 0.7) || (LeftRightAlt >= 0.7) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
				if (!hasExecuted)
					NextSelect ();
				hasExecuted = true;
			} else {
				hasExecuted = false;
			}
			break;
		case 1:
            if ((UpDown >= 0.7) || (UpDownAlt >= 0.7) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
				if (!hasExecuted)
					PrevSelect ();
				hasExecuted = true;
            }
            else if ((UpDown <= -0.7) || (UpDownAlt <= -0.7) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
				if (!hasExecuted)
					NextSelect ();
				hasExecuted = true;
            }
            else if ((LeftRight >= 0.7) || (LeftRightAlt >= 0.7) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
				if (!hasExecuted)
					states [state].NextSelect ();
				hasExecuted = true;
            }
            else if ((LeftRight <= -0.7) || (LeftRightAlt <= -0.7) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
				if (!hasExecuted)
					states [state].PrevSelect ();
				hasExecuted = true;
			} else {
				hasExecuted = false;
			}
			break;
		case 3:
            if ((LeftRight <= -0.7) || (LeftRightAlt <= -0.7) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
				if (!hasExecuted)
					states [state].PrevSelect ();
				hasExecuted = true;
            }
            else if ((LeftRight >= 0.7) || (LeftRightAlt >= 0.7) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
				if (!hasExecuted)
					states [state].NextSelect ();
				hasExecuted = true;
            }
            else if ((UpDown <= -0.7) || (UpDownAlt <= -0.7) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
				if (!hasExecuted)
					NextSelect ();
				hasExecuted = true;
            }
            else if ((UpDown >= 0.7) || (UpDownAlt >= 0.7) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
				if (!hasExecuted)
					PrevSelect ();
				hasExecuted = true;
			} else {
				hasExecuted = false;
			}
			break;
		}
        if ((Input.GetKeyDown("joystick button 0"))||(Input.GetKeyDown(KeyCode.Return)))
        {
            states[state].Submit();
            hasExecuted = true;
        }
    }

    public override void SetState(int s)
    {
        states[state].OnExit();

        base.SetState(s);

        foreach (SubMenu h in states)
        {
            h.visible = false;
        }
        states[state].visible = true;
        states[state].OnEnter();
    }

    public override void Submit()
    {
        throw new System.NotImplementedException();
    }
}
