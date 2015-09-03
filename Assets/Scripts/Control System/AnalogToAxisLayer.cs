using UnityEngine;
using System.Collections;

public class AnalogToAxisLayer : Axis 
{
	[SerializeField] string axisName;
	[SerializeField] float deadZone = 0.1f;
	[SerializeField] bool invert;

//	public new float axisValue {
//		get{
//			//if(focus){
//				string AxisName = "P"+joystick+" ";
//				if(direction == StickDirection.HORIZONTAL){
//					AxisName += "Horizontal ";
//				} else {
//					AxisName += "Vertical ";
//				}
//				if(type == StickType.MOVEMENT){
//					AxisName += "Movement";
//				} else {
//					AxisName += "Attack";
//				}
//			Debug.Log("axis value called");
//				return 
//			}
//			return 0;
//		}
//	}

	void Update(){
		_axisValue = Input.GetAxisRaw(axisName);
		if(invert){_axisValue *=-1;}
		if(Mathf.Abs(_axisValue) < deadZone){
			_axisValue = 0;
		}
		Debug.Log(_axisValue);
	}

//	public int joystick;
//	[SerializeField] StickDirection direction;
//	[SerializeField] StickType type;
}

public enum StickType{
	MOVEMENT, ATTACK
}

public enum StickDirection{
	HORIZONTAL, VERTICAL
}