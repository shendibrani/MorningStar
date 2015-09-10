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

	void UpdateImage ()
	{
		foreach (Image i in states) {
			i.color = Color.clear;
		}
		states [state].color = Color.white;
	}
}
