using UnityEngine;
using System.Collections;

public class MainMenu_StateMachine : MonoBehaviour {


	/* 1 = StartGame
	 * 2= Rules/Settings
	 * 3= Credits
	 * 4=Exit
	 * 5 = Tutorial
	 * 6 = Scoreboard
	 * 7= selection
	*/

	private int MenuState = 1;

	public Animator start;
	public Animator rules;
	public Animator credits;
	public Animator exit;
	public Animator tutorial;
	public Animator scoreboard;

	public Animator arrowRight;
	public Animator arrowLeft;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
		
			if (Input.GetKeyDown (KeyCode.RightArrow)) {

				arrowRight.SetBool ("Active", true);

				if (MenuState < 6) {
					MenuState++;
				} else {
					MenuState = 1;
				}
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {

				arrowLeft.SetBool ("Active", true);

				if (MenuState > 1) {
					MenuState--;
				} else {
					MenuState = 6;
				}
			}
			
			start.SetInteger ("MenuState", MenuState);
			rules.SetInteger ("MenuState", MenuState);
			credits.SetInteger ("MenuState", MenuState);
			exit.SetInteger ("MenuState", MenuState);
			tutorial.SetInteger ("MenuState", MenuState);
			scoreboard.SetInteger ("MenuState", MenuState);
		} else {

			arrowRight.SetBool ("Active", false);
			arrowLeft.SetBool ("Active", false);
		}

	}
}
