using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMenuAnimations : MonoBehaviour {


	//public Animator arrowRight;
	//public Animator arrowLeft;

	public Transform rightArrow;
	public Transform leftArrow;

	/*0 = Exit
	 * 1 = Char
	 * 2 = Weapon
	 * 3 = Ready
*/

	private int _state = 1;

	// Use this for initialization
	void Start () {
		rightArrow.position = new Vector3(182, 344,0);
		leftArrow.position = new Vector3(-172, 344,0);
	}
	
	// Update is called once per frame
	void Update () {

	/*	if (Input.GetKeyDown (KeyCode.RightArrow)) {
			
			arrowRight.SetBool ("Active", true);

		}

		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			
			arrowLeft.SetBool ("Active", true);

		}
		else {
			arrowRight.SetBool ("Active", false);
			arrowLeft.SetBool ("Active", false);
		}
*/
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (_state < 3) {

				_state ++;

				if (_state == 1) {

					//rightArrow.position = new Vector3(182, 344,0);
					leftArrow.position = new Vector3(-172, 344,0);
					rightArrow.GetComponent<Image>().enabled = true;
					
				}

				if (_state == 2) {
					rightArrow.position = new Vector3(182, 32,0);
					leftArrow.position = new Vector3(-172, 32,0);
				}

				if (_state == 3) {
					
					leftArrow.GetComponent<Image>().enabled = false;
					rightArrow.GetComponent<Image>().enabled = false;
				}


			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (_state > 0) {

				_state --;

				if (_state == 2) {
					rightArrow.position = new Vector3(182, 32,0);
					leftArrow.position = new Vector3(-172, 32,0);
					leftArrow.GetComponent<Image>().enabled = true;
					rightArrow.GetComponent<Image>().enabled = true;
				}

				if (_state == 1) {
					
					rightArrow.position = new Vector3(182, 344,0);
					leftArrow.position = new Vector3(-172, 344,0);
					
				}
				if (_state == 0) {

					rightArrow.GetComponent<Image>().enabled = false;
					leftArrow.position = new Vector3(-886, 447,0);
				}


			}
		}



	}
}
