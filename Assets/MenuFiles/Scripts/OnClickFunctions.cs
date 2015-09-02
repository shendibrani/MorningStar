using UnityEngine;
using System.Collections;

public class OnClickFunctions : MonoBehaviour {

	public void LoadThisScene (int level) {
		Application.LoadLevel (level);

	}

	public void ExitGame () {
		Application.Quit ();

	}
}
