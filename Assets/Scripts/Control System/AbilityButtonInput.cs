using UnityEngine;
using System.Collections;

public class AbilityButtonInput : MonoBehaviour {

	[SerializeField] Axis abilityAxis;

    //[SerializeField] Ability plusAbility;
    //[SerializeField] Ability minusAbility;

    bool hasExecuted = false;

    void Update()
    {
        Debug.Log("trigger value " + abilityAxis.axisValue);
        if (abilityAxis.axisValue >= 0.7f && !hasExecuted)
        {
            GetComponent<DashAbility>().Execute();
//plusAbility.Execute();
            hasExecuted = true;
        }
		else if (abilityAxis.axisValue <= -0.7f && !hasExecuted) 
        {
            foreach (Ability a in GetComponents<Ability>())
            {
                if (a != GetComponent<DashAbility>())
                {
                    a.Execute();
                    hasExecuted = true;
                }
            }

        }
		else if (abilityAxis.axisValue < 0.7f && abilityAxis.axisValue > -0.7f)
        {
            hasExecuted = false;
        }
       
       
	}
}
