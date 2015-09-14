using UnityEngine;
using System.Collections;

public class AxisSelector : Selector
{
	[SerializeField] string[] xAxisNames;
	[SerializeField] string[] yAxisNames;

	public string xAxis { get { return xAxisNames[state]; }}
	public string yAxis { get { return yAxisNames[state]; }}
}

