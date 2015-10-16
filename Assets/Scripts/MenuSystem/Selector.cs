using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Selector : SubMenu<Image> {

	protected override void Start ()
	{
		base.Start ();
		UpdateImage();
	}

	public override void NextState ()
	{
		base.NextState ();
		UpdateImage ();
	}

	public override void PrevState ()
	{
		base.PrevState ();
		UpdateImage();
	}

	public override void SetState (int s)
	{
		base.SetState (s);
		UpdateImage();
	}

	public void AddState(GameObject go){
		if (go.GetComponent<Image> () == null || go.GetComponent<RectTransform> () == null) {
			throw new UnityException(
				"The GameObject can't be used as a state in a submenu, it lacks either a RectTnsform, an Image, or both"
				);
			return;
		}

		go.GetComponent<RectTransform> ().SetParent(GetComponent<RectTransform> ());
		go.GetComponent<RectTransform> ().localScale = new Vector2 (2.5f, 2.5f);
		go.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (200, 0);

		states.Add (go.GetComponent<Image> ());

		UpdateImage ();
	}

	void UpdateImage ()
	{
		if (states.Count == 0) {
			return;
		}
		foreach (Image i in states) {
			i.color = Color.clear;
		}
		states [state].color = Color.white;
	}
}
