using UnityEngine;
using System.Collections;

public class CheckStructure : MonoBehaviour {
    RaycastHit storeHere;
    Ray ray;
   
    void Update() {
    //    if (!Physics.Raycast(transform.position, Vector3.right, 10) && !Physics.Raycast(transform.position, Vector3.left, 10)) {
    //        this.transform.parent = null;

    //        gameObject.AddComponent<Rigidbody>();
    //        Debug.Log("No touch");
    //    }

    }

    void OnEnterTrigger(Collider col) {
        if (!col.gameObject.CompareTag("CratePiece")) {
            this.transform.parent = null;
            gameObject.AddComponent<Rigidbody>();
        }
    }
  
}
