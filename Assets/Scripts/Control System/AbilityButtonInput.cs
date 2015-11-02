using UnityEngine;
using System.Collections;

public class AbilityButtonInput : MonoBehaviour {

	[SerializeField] Axis abilityAxis;

    [SerializeField] Ability dashAbility;
    [SerializeField] Ability defaultAbility;
    [SerializeField] Ability boomerangAbility;

    bool hasExecuted = false;
    bool hasSpecial = false;

    public void PickupSpecial()
    {
        hasSpecial = true;
    }

    void Update()
    {
        if (GetComponentInParent<PlayerInfo>().State != PlayerInfo.PlayerState.DEAD)
        {
            Debug.Log("trigger value " + abilityAxis.axisValue);
            if (abilityAxis.axisValue >= 0.7f && !hasExecuted)
            {
                dashAbility.Execute();
                hasExecuted = true;
            }
            else if (abilityAxis.axisValue <= -0.7f && !hasExecuted)
            {
                if (hasSpecial)
                {
                    boomerangAbility.Execute();
                    hasSpecial = false;
                }
                else
                {
                    defaultAbility.Execute();
                }
                hasExecuted = true;

            }
            else if (abilityAxis.axisValue < 0.7f && abilityAxis.axisValue > -0.7f)
            {
                hasExecuted = false;
            }
        }
    }
}
