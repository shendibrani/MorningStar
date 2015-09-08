using UnityEngine;
using System.Collections;

public class AbilityButtonInput : KeyboardToAxisLayer {

    [SerializeField]
    Ability plusAbility;
    [SerializeField]
    Ability minusAbility;

    bool hasExecuted = false;



	// Use this for initialization
	void Start () {

	}

    void Update()
    {
        base.Update();
        
        if (axisValue == 1 && !hasExecuted)
        {
            plusAbility.Execute();
            hasExecuted = true;
        }
        else if (axisValue == -1 && !hasExecuted) 
        {
            minusAbility.Execute();
            hasExecuted = true;
        }
        else if (axisValue != 1 && axisValue != -1)
        {
            hasExecuted = false;
        }
       
       
	}
}
