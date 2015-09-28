using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	public AxisPair movement, attack;
	public Axis triggers;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

[System.Serializable]
public struct AxisPair
{
	public Axis x,y;
}