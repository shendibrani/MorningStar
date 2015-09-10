using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public interface IStateBasedUI {

	bool visible {get ; set;}

	void Hide();
	void Show ();
}