using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatbarsBehaviour : MonoBehaviour {

	[SerializeField] List<BarBehaviour> bars;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateValues(float[] values)
	{
		for (int counter = 0; counter < bars.Count && counter < values.Length; counter++){
			bars[counter].currentValue = values[counter];
		}
	}
}
