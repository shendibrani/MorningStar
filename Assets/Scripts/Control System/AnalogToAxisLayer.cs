using UnityEngine;
using System.Collections;

public class AnalogToAxisLayer : Axis 
{

	[SerializeField] float deadZone = 0.1f;
	public int player {get; set;}
	public StickDirection direction;
	public StickType type;

	public string axisName;

	void Update(){
		_axisValue = Input.GetAxisRaw(axisName);
		if(Mathf.Abs(_axisValue) < deadZone){
			_axisValue = 0;
		}
		//Debug.Log(_axisValue);
	}
}

public enum StickType{
	MOVEMENT, ATTACK, TRIGGER
}

public enum StickDirection{
	HORIZONTAL, VERTICAL
}