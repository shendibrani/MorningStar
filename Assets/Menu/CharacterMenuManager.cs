using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterMenuManager : MonoBehaviour {

	/* 0 = Exit
	 * 1 = Char
	 * 2 = Weapon
	 * 3 = Ready
	 */

	[SerializeField] List<Highlightable> objects;

	[SerializeField] int state;

	// Use this for initialization
	void Start () {
		UpdateHighlighting ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)){
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				state++;
			} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
				state--;
			}

			state = (state%objects.Count + objects.Count)%objects.Count;

			UpdateHighlighting ();
		}
	}

	void UpdateHighlighting ()
	{
		foreach (Highlightable h in objects){
			h.SetHighlight(false);
		}

		objects[state].SetHighlight(true);
	}
}
