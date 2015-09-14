using UnityEngine;
using System.Collections;

public class DestroyBreakable : MonoBehaviour
{

    [SerializeField]
    float timer = 150f;

    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

    void customDestroy()
    {
        if (this.transform.position.y < 0) Destroy(gameObject);

        timer -= 1f;
        
        Destroy(this.gameObject, 10f);
        if (timer <= 0)
        {
       
            rb.WakeUp();
            rb.isKinematic = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }

    }

   

    void Start()
    {

        
    }

    void Update()
    {
        
        customDestroy();

    }
}
