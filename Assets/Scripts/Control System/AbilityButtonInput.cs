using UnityEngine;
using System.Collections;

public class AbilityButtonInput : MonoBehaviour {

	[SerializeField] Axis abilityAxis;

    [SerializeField] Ability plusAbility;
    [SerializeField] Ability minusAbility;

    bool hasExecuted = false;

    void Update()
    {
        if (abilityAxis.axisValue == 1 && !hasExecuted)
        {
            plusAbility.Execute();
            hasExecuted = true;
        }
		else if (abilityAxis.axisValue == -1 && !hasExecuted) 
        {
            minusAbility.Execute();
            hasExecuted = true;
        }
		else if (abilityAxis.axisValue != 1 && abilityAxis.axisValue != -1)
        {
            hasExecuted = false;
        }
       
       
	}
}
