using UnityEngine;
using System.Collections;

public class DecayControl : MonoBehaviour {

    [SerializeField]
    float decayTime = 10f;
    float fallTime = 5f;
    float timer;
    [SerializeField]
    DecayState state = DecayState.ALIVE;

    enum DecayState
    {
        ALIVE, DEAD, FALLING
    };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Time.time > timer))
        {
            switch (state){
                case DecayState.DEAD:
                    SetFalling();
                    break;
                case DecayState.FALLING:
                    Destroy(this.gameObject);
                    break;
            }
        }     
	}

    void SetFalling()
    {
        foreach(Collider c in GetComponentsInChildren<Collider>()){
               c.enabled = true;
               c.isTrigger = true;
               if (c.GetComponent<Rigidbody>()) c.GetComponent<Rigidbody>().useGravity = true;
           }
        timer = Time.time + fallTime;
        state = DecayState.FALLING;
    }

    public void Activate()
    {
        timer = decayTime + Time.time;
        state = DecayState.DEAD;
    }
}
