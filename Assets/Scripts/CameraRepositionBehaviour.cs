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
            transform.LookAt(center);
            transform.position += (targetPosition - transform.position) * easing;

        }

        if (a == null && b == null)
        {
            if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward);
            if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right);
            if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left);
            if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back);
        }

        

    }
}
