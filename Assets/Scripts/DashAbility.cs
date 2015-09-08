using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DashAbility : Ability {

    Transform other;

    [SerializeField]
    Axis upDown;
    [SerializeField]
    Axis leftRight;
    [SerializeField]
    float dashPower;
    [SerializeField]
    float interval = 1f;

    float timer = 0;

	// Use this for initialization
	void Start () {
        List<LookAtEachotherBehaviour> list = new List<LookAtEachotherBehaviour>(FindObjectsOfType<LookAtEachotherBehaviour>());
        other = list.Find(x => x != this).transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public override void Execute()
    {
        if (Time.time >= timer)
        {
            if (leftRight.axisValue != 0 || upDown.axisValue != 0)
            {
                Debug.Log("Aimed");
                GetComponent<Rigidbody>().AddForce((new Vector3(leftRight.axisValue, 0, upDown.axisValue).normalized) * dashPower, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Auto");
                Vector3 difference = this.transform.position - other.transform.position;
                GetComponent<Rigidbody>().AddForce((new Vector3(difference.x, 0, difference.y).normalized) * dashPower, ForceMode.Impulse);
            }
            timer = interval + Time.time;
        }

    }
}
