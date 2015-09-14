using UnityEngine;
using System.Collections;

public class CameraRepositionBehaviour : MonoBehaviour {

    public GameObject a, b;
    float yPosition;

    [SerializeField] float easing = 0.2f;

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3();

        if (a != null && b != null)
        {
            Vector3 center = (b.transform.position - a.transform.position) / 2 + a.transform.position;
            targetPosition = new Vector3(center.x, yPosition, center.z);
            //transform.LookAt(center);

            transform.position += (targetPosition - transform.position) * easing;
        }

        else if (a == null || b == null)
        {
            Debug.Log("Target A and B null from Camera, switching to manual cam controls, Press ASWD to move camera");
            if (Input.GetKey(KeyCode.D)) this.transform.Translate(Vector3.right);
            if (Input.GetKey(KeyCode.A)) this.transform.Translate(Vector3.left);

            if (Input.GetKey(KeyCode.W)) this.transform.Translate(Vector3.up);
            if (Input.GetKey(KeyCode.S)) this.transform.Translate(Vector3.down);
        }




    }
}
