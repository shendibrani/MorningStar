using UnityEngine;
using System.Collections;

public class CreditsMenu : SubMenu 
{


	public override void Submit ()
	{
		overlord.SetState(0);
	}

	public override void NextState (){}

	public override void PrevState () {}

	public override void SetState (int i) {}

	public override void NextSelect () {}

	public override void PrevSelect () {}
}

