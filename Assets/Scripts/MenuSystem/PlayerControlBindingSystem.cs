﻿using UnityEngine;
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
        Debug.Log("Controller Setup Passed");
        UpdateHighlighting();
        PlayerInfoPasser.SetControllers(controllers);
        Debug.Log("Controller Data Passed");
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
		string[] joystickNames = Input.GetJoystickNames ();

		int controllerCount = 0;

		for (int counter = 0; counter < joystickNames.Length; counter++) 
		{
			if(joystickNames[counter] == "Controller (Xbox 360 Wireless Receiver for Windows)" ||
                joystickNames[counter] == "Controller (Rumble Gamepad F510)" ||
                joystickNames[counter] == "Controller(XBOX 360 For Windows)")
            {

				Debug.Log ("Found " + joystickNames[counter] + "In position " + (counter+1));

				string[] contr = new string[5];

				contr[0] = "J"+ (counter + 1) + " Left Stick X";
				contr[1] = "J"+ (counter + 1) + " Left Stick Y";
				contr[2] = "J"+ (counter + 1) + " XB Right Stick X";
				contr[3] = "J"+ (counter + 1) + " XB Right Stick Y";
				contr[4] = "J"+ (counter + 1) + " XB Triggers";

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

				contr[0] = "J"+ (counter + 1) + " FF Face X";
				contr[1] = "J"+ (counter + 1) + " FF Face Y";
				contr[2] = "J"+ (counter + 1) + " FF Right Stick X";
				contr[3] = "J"+ (counter + 1) + " FF Right Stick Y";
				contr[4] = "J"+ (counter + 1) + " FF Right Triggers";
				
				GameObject selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[1];
				p1.AddState(selection);
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[1];
				p2.AddState(selection);

				//////////////////////////////////////////////////////////////////////////////////

				contr[0] = "J"+ (counter + 1) + " FF DPad X";
				contr[1] = "J"+ (counter + 1) + " FF DPad Y";
				contr[2] = "J"+ (counter + 1) + " Left Stick X";
				contr[3] = "J"+ (counter + 1) + " Left Stick Y";
				contr[4] = "J"+ (counter + 1) + " FF Left Triggers";
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[2];
				p1.AddState(selection);
				
				selection = GameObject.Instantiate(selectionTemplate);
				selection.GetComponent<Controller>().array = contr;
				selection.GetComponent<Image>().sprite = ultimateArcadeIcons[2];
				p2.AddState(selection);

                //////////////////////////////////////////////////////////////////////////////////

                contr[0] = "J" + (counter + 1) + " Left Stick X";
                contr[1] = "J" + (counter + 1) + " Left Stick Y";
                contr[2] = "J" + (counter + 1) + " FF Right Stick X";
                contr[3] = "J" + (counter + 1) + " FF Right Stick Y";
                contr[4] = "J" + (counter + 1) + " FF Triggers";

                selection = GameObject.Instantiate(selectionTemplate);
                selection.GetComponent<Controller>().array = contr;
                selection.GetComponent<Image>().sprite = ultimateArcadeIcons[0];
                p1.AddState(selection);

                selection = GameObject.Instantiate(selectionTemplate);
                selection.GetComponent<Controller>().array = contr;
                selection.GetComponent<Image>().sprite = ultimateArcadeIcons[0];
                p2.AddState(selection);

                //////////////////////////////////////////////////////////////////////////////////
            }
		}
		
		p1.SetState (0);
		controllers [0].array = p1.stateObject.GetComponent<Controller> ().array;
		p2.SetState (1);
		controllers [1].array = p2.stateObject.GetComponent<Controller> ().array;
	}
}