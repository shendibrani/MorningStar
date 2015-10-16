using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerControlBindingSystem : SubMenu<Highlightable>
{

    bool getInput;

    [SerializeField] Controller[] controllers;

	[SerializeField] Selector p1,p2;

	[SerializeField] GameObject selectionTemplate;

	[SerializeField] Sprite[] genericControllerIcons, ultimateArcadeIcons;

    bool hasExecuted = false;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
		ControllerSetup ();
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

	void ControllerSetup()
	{
		string lx, ly, rx, ry, t;

		string[] joystickNames = Input.GetJoystickNames ();

		int controllerCount = 0;

		for (int counter = 0; counter < joystickNames.Length; counter++) 
		{
			if(joystickNames[counter] == "Controller (Xbox 360 Wireless Receiver for Windows)"){

				Debug.Log ("Found "+joystickNames[counter]);

				string[] contr = new string[5];

				contr[0] = "J"+counter+" Left Stick X";
				contr[1] = "J"+counter+" Left Stick Y";
				contr[2] = "J"+counter+" XB Right Stick X";
				contr[3] = "J"+counter+" XB Right Stick Y";
				contr[4] = "J"+counter+" XB Triggers";

				GameObject selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = genericControllerIcons[controllerCount];
				p1.AddState(selection);

				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = genericControllerIcons[controllerCount];
				p2.AddState(selection);

				controllerCount++;

			} else if (joystickNames[counter] == "Ultimate Arcade Controller v2.0") {

				Debug.Log ("Found "+joystickNames[counter]);

				string[] contr = new string[5];
				
				contr[0] = "J"+counter+" Left Stick X";
				contr[1] = "J"+counter+" Left Stick Y";
				contr[2] = "J"+counter+" FF Right Stick X";
				contr[3] = "J"+counter+" FF Right Stick Y";
				contr[4] = "J"+counter+" FF Triggers";
				
				GameObject selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[0];
				p1.AddState(selection);
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[0];
				p2.AddState(selection);

				//////////////////////////////////////////////////////////////////////////////////

				contr[0] = "J"+counter+" FF Face X";
				contr[1] = "J"+counter+" FF Face Y";
				contr[2] = "J"+counter+" FF Right Stick X";
				contr[3] = "J"+counter+" FF Right Stick Y";
				contr[4] = "J"+counter+" FF Right Triggers";
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[1];
				p1.AddState(selection);
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[1];
				p2.AddState(selection);

				//////////////////////////////////////////////////////////////////////////////////

				contr[0] = "J"+counter+" FF DPad X";
				contr[1] = "J"+counter+" FF DPad Y";
				contr[2] = "J"+counter+" Left Stick X";
				contr[3] = "J"+counter+" Left Stick Y";
				contr[4] = "J"+counter+" FF Left Triggers";
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[2];
				p1.AddState(selection);
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[2];
				p2.AddState(selection);
			}
		}
		
		p1.SetState (0);
		controllers [0].array = p1.stateObject.GetComponent<Controller> ().array;
		p2.SetState (1);
		controllers [1].array = p2.stateObject.GetComponent<Controller> ().array;
	}
}