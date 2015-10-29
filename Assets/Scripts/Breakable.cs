using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
    //Code in script only useful for triggering egg replacement 
    // to imitate destruction

    public GameObject replacementGO;
    public int healthBonus;
    

    void OnCollisionEnter(Collision col)
    {
        if (this.gameObject.tag == "EggFull")
        OnBreakableInstantiation(col);
    }

    void OnBreakableInstantiation(Collision col)
    {

        Debug.Log("Touching eggy");
        if (col.gameObject.GetComponent<OnCollisionCalls>() || col.gameObject.CompareTag("Player") )
        {
            Debug.Log("\n Attacking Player Health: " + col.collider.GetComponentInParent<ReceiveDamageOnCollision>().health);

            Destroy(gameObject);
            replacementGO = (GameObject)Instantiate(replacementGO, gameObject.transform.position, Quaternion.identity);

            col.collider.GetComponentInParent<ReceiveDamageOnCollision>().health += healthBonus;
            Debug.Log("Health + 20 should activate");
            for (int i = 0; i < replacementGO.transform.childCount; i++) {
                Transform newTransform = replacementGO.transform.GetChild(i);
                newTransform.gameObject.AddComponent<DestroyBreakable>();
            }
        }
    }


}
