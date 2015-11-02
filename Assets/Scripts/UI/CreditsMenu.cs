using UnityEngine;
using System.Collections;

public class CreditsMenu : SubMenu 
{
    void Start()
    {
        overlord = FindObjectOfType<MenuOverlord>();
    }

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

