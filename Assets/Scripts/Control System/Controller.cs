using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	public AxisPair movement, attack;
	public Axis triggers;
}

[System.Serializable]
public struct AxisPair
{
	public Axis x,y;
}