using UnityEngine;
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
    Axis UpDown, LeftRight;

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
        switch (state)
        {
            case 0:
                if ((LeftRight <= -0.9)||(Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    if (!hasExecuted) PrevSelect();
                    hasExecuted = true;
                }
                else if ((LeftRight >= 0.9)||(Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    if (!hasExecuted) NextSelect();
                    hasExecuted = true;
                }
                else
                {
                    hasExecuted = false;
                }
                break;
            case 1:
                if ((UpDown >= 0.9)||(Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    if (!hasExecuted) PrevSelect();
                    hasExecuted = true;
                }
                else if ((UpDown <= -0.9)||(Input.GetKeyDown(KeyCode.DownArrow)))
                {
                    if (!hasExecuted) NextSelect();
                    hasExecuted = true;
                }
                else if ((LeftRight >= 0.9)||(Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    if (!hasExecuted) states[state].NextSelect();
                    hasExecuted = true;
                }
                else if ((LeftRight <= -0.9)||(Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    if (!hasExecuted)  states[state].PrevSelect();
                    hasExecuted = true;
                }
                else
                {
                    hasExecuted = false;
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
                PCBS.SendAxes(LeftRight, UpDown);
                break;
        }
        if ((Input.GetKeyDown("joystick 1 button 0"))||(Input.GetKeyDown(KeyCode.Return)))
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
