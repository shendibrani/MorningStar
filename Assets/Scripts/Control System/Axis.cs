using UnityEngine;
using System.Collections;

public abstract class Axis : MonoBehaviour {

	protected float _axisValue;

	protected bool focus { get; private set;}

	public float axisValue { 
		get { 
			if (invert){
				return _axisValue * -1;
			} 
			return _axisValue; 
		} 
	}

	public bool invert;

	void OnApplicationFocus(bool focus){
		this.focus = focus;
	}

	public static implicit operator float (Axis a){
		return a.axisValue;
	}
}
