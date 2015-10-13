using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	public AxisPair movement, attack;
	public AnalogToAxisLayer triggers;

	public string[] array {
		get {
			string[] result = new string[5];
			result[0] = movement.array[0];
			result[1] = movement.array[1];
			result[2] = attack.array[0];
			result[3] = attack.array[1];
			result[4] = triggers.axisName;
			return result;
		}
		set {
			if(value.Length != 5){
				throw(new UnityException("The Array is not the right size for a controller initialization"));
			}
			string[] temp = new string[2];
			temp[0] = value[0];
			temp[1] = value[1];
			movement.array = temp;
			temp[0] = value[2];
			temp[1] = value[3];
			attack.array = temp;
			triggers.axisName = value[4];
		}
	}
}

[System.Serializable]
public struct AxisPair
{
	public AnalogToAxisLayer x,y;

	public string[] array {
		get {
			string[] result = new string[2];
			result[0] = x.axisName;
			result[1] = y.axisName;
			return result;
		}
		set {
			if(value.Length != 2){
				throw(new UnityException("The Array is not the right size for an axis pair initialization"));
			} else {
				x.axisName = value[0];
				y.axisName = value[1];
			}
		}
	}
}