using UnityEngine;
using System.Collections;

public abstract class Axis : MonoBehaviour {

	protected float _axisValue;

	protected bool focus { get; private set;}

	public float axisValue { get { return _axisValue; } }

	void OnApplicationFocus(bool focus){
		this.focus = focus;
	}

	public static implicit operator float (Axis a){
		return a.axisValue;
	}
}
