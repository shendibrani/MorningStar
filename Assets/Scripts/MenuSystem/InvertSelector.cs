using UnityEngine;
using System.Collections;

public class InvertSelector : Selector
{
	public bool invert
	{
		get{
			return state == 1;
		}
	}
}

