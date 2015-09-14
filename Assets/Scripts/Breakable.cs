using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
    //Code in script only useful for triggering egg replacement 
    // to imitate destruction

    public GameObject replacementGO;

    void OnCollisionEnter(Collision col)
    {
        if (this.gameObject.name == "EggFull")
        OnBreakableInstantiation(col);
    }

    void OnBreakableInstantiation(Collision col)
    {
        if (col.gameObject.GetComponent<OnCollisionCalls>() && col.relativeVelocity.magnitude >2 )
        {
            Destroy(gameObject);
            replacementGO = (GameObject)Instantiate(replacementGO, gameObject.transform.position, Quaternion.identity);

            for (int i = 0; i < replacementGO.transform.childCount; i++) {
                Transform newTransform = replacementGO.transform.GetChild(i);
                newTransform.gameObject.AddComponent<DestroyBreakable>();
            }
        }
    }
}
