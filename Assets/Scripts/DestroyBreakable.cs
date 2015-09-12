using UnityEngine;
using System.Collections;

public class DestroyBreakable : MonoBehaviour {
    Vector3 downPosition;
    public float DestructionTime;
   [SerializeField] float timer = 100f;

    void customDestroy(float destroyInTime) {

        Destroy(this.gameObject, destroyInTime);
        if (timer <= 0) this.GetComponent<BoxCollider>().enabled = false;

    }

    void Start() {
      
        customDestroy(5f);
    }

    void Update() {
        timer -= 1f;
        

    }
}
