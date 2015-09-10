using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(RectTransform))]
public class UIDrawerBehaviour : MonoBehaviour {

	[SerializeField] List<Vector2> positions;
	[SerializeField] float easing;

	int currentPosition = 0;

	// Update is called once per frame
	void Update () {
		RectTransform rectTransform = GetComponent<RectTransform> ();
		rectTransform.anchoredPosition += (positions[currentPosition] - rectTransform.anchoredPosition)*easing;

		if (Input.GetKeyDown (KeyCode.Tab)) {
			NextPosition ();
		}
	}

	public void NextPosition ()
	{
		currentPosition++;
		currentPosition %= positions.Count;
	}

	public void NextPosition (int i)
	{
		currentPosition = i;
		currentPosition %= positions.Count;
	}
}
