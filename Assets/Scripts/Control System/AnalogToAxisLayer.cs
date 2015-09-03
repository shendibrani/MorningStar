using UnityEngine;
using System.Collections;

public class AnalogToAxisLayer : Axis 
{
	public new float axisValue {
		get{
			if(focus){
				string AxisName = "P"+joystick+" ";
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
				Input.GetAxis(AxisName);
			}
			return 0;
		}
	}

	[SerializeField] int joystick;
	[SerializeField] StickDirection direction;
	[SerializeField] StickType type;
}

public enum StickType{
	MOVEMENT, ATTACK
}

public enum StickDirection{
	HORIZONTAL, VERTICAL
}