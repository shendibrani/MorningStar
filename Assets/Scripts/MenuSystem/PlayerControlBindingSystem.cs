using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerControlBindingSystem : SubMenu<Highlightable>
{

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

    [SerializeField]
    Controller[] controllers;

    bool hasExecuted = false;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        UpdateHighlighting();
        PlayerInfoPasser.SetControllers(controllers);
    }

    #region IStateMachine

    public override void NextState()
    {
        base.NextState();
        UpdateHighlighting();
    }

    public override void PrevState()
    {
        base.PrevState();
        UpdateHighlighting();
    }

    public override void SetState(int s)
    {
        base.SetState(s);
        UpdateHighlighting();
    }

    public override void Submit()
    {
        if (state == 2)
        {
            //controllers = new Controller[2];
            for (int counter = 0; counter < 2; counter++)
            {
                Debug.Log(controllers[counter]);
                Debug.Log(states[counter].GetComponent<Selector>().stateObject.GetComponent<Controller>());
				controllers[counter].attack = states[counter].GetComponent<Selector>().stateObject.GetComponent<Controller>().attack;
                controllers[counter].movement = states[counter].GetComponent<Selector>().stateObject.GetComponent<Controller>().movement;
                controllers[counter].triggers = states[counter].GetComponent<Selector>().stateObject.GetComponent<Controller>().triggers;
            }
            overlord.SetState(0);
        }
        else
        {
            base.Submit();
        }
    }

    #endregion

    void UpdateHighlighting()
    {
        foreach (Highlightable h in states)
        {
            h.GetComponent<Highlightable>().SetHighlight(false);
        }

        states[state].SetHighlight(true);
    }
}