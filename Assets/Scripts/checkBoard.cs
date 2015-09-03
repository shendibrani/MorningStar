using UnityEngine;
using System.Collections;

public class checkBoard : MonoBehaviour {

    public Animator animElevator;

    void OnTriggerEnter(Collider c) {
       
            animElevator.SetBool("OnBoard", true);
            
    }

    void OnTriggerExit(Collider c) {

        animElevator.SetBool("OnBoard", false);
    }
}
