using UnityEngine;
using System.Collections;

public class KeyboardToAxisLayer : Axis {

	//[SerializeField] protected KeyCode plus;
	//[SerializeField] protected KeyCode minus;
    public int player { get; set; }

    string axisName
    {
        get
        {
            string AxisName = "P" + player + " Ability Buttons";
            return AxisName;
        }
    }

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
        _axisValue = Input.GetAxisRaw(axisName);
        //if(focus){
        //    _axisValue = 0;

        //    if(Input.GetKey(plus)){
        //        _axisValue = 1;
        //    } else if(Input.GetKey(minus)){
        //        _axisValue = -1;
        //    }
        //}
	}
}
