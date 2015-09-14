using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(RectTransform))]
public class UIDrawerBehaviour : MonoBehaviour {

	[SerializeField] List<Vector2> positions;
	[SerializeField] float easing;

	public int state {get; private set;}

	// Update is called once per frame
	void Update () {
		RectTransform rectTransform = GetComponent<RectTransform> ();
		rectTransform.anchoredPosition += (positions[state] - rectTransform.anchoredPosition)*easing;

		if (Input.GetKeyDown (KeyCode.Tab)) {
			NextState ();
		}
	}

	#region IStateMachine Implementation

	public void NextState ()
	{
		state++;
		state = (state%positions.Count + positions.Count)%positions.Count;
	}

	public void SetState (int i)
	{
		state = i;
		state = (state%positions.Count + positions.Count)%positions.Count;	
	}

	public void PrevState()
	{
		state++;
		state = (state%positions.Count + positions.Count)%positions.Count;	
	}

	public void NextSelect(){}
	public void PrevSelect(){}

	public void Submit(){}

	public void OnEnter(){}

	public void OnExit(){}

	#endregion
}
