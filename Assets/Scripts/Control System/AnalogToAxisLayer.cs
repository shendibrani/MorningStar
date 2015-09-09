using UnityEngine;
using System.Collections;

public class AnalogToAxisLayer : Axis 
{

	[SerializeField] float deadZone = 0.1f;
	[SerializeField] bool invert;
	public int player {get; set;}
	[SerializeField] StickDirection direction;
	[SerializeField] StickType type;

	string axisName {
		get{ 
			string AxisName = "P"+player+" ";
            if (type == StickType.TRIGGER)
            {
                AxisName += "Trigger Buttons";
                return AxisName;
            }
			if(direction == StickDirection.HORIZONTAL){
				AxisName += "Horizontal ";
			} else {
				AxisName += "Vertical ";
			}
			if(type == StickType.MOVEMENT){
				AxisName += "Movement";
			} else {
				AxisName += "Attack";
			}
			return AxisName;
		}
	}

	void Start(){

	}

	void Update(){
		_axisValue = Input.GetAxisRaw(axisName);
		if(invert){_axisValue *=-1;}
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