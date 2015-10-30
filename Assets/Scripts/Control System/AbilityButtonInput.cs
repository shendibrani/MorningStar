using UnityEngine;
using System.Collections;

public class AbilityButtonInput : MonoBehaviour {

	[SerializeField] Axis abilityAxis;

    //[SerializeField] Ability plusAbility;
    //[SerializeField] Ability minusAbility;

    bool hasExecuted = false;

    void Update()
    {
        if (abilityAxis.axisValue >= 0.9f && !hasExecuted)
        {
            GetComponent<DashAbility>().Execute();
//plusAbility.Execute();
            hasExecuted = true;
        }
		else if (abilityAxis.axisValue <= -0.9f && !hasExecuted) 
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
		else if (abilityAxis.axisValue < 0.9f && abilityAxis.axisValue > -0.9f)
        {
            hasExecuted = false;
        }
       
       
	}
}
