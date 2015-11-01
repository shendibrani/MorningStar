using UnityEngine;
using System.Collections;

public class CameraRepositionBehaviour : MonoBehaviour {

    public GameObject a, b;
    float yPosition;

    [SerializeField] float easing = 0.2f;

    [SerializeField]
    float cameraDistance = 10f;

    [SerializeField]
    float cameraAngle = 30f;

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3();

        if (a != null && b != null)
        {
			yPosition = (b.transform.position - a.transform.position).magnitude + cameraDistance;

            Vector3 center = (b.transform.position - a.transform.position) / 2 + a.transform.position;
            transform.eulerAngles = new Vector3(cameraAngle, 0, 0);
            Vector3 offset = -transform.forward * yPosition;
            targetPosition = offset + center;
            transform.position += (targetPosition - transform.position) * easing;



            //Vector3 offset = center + new Vector3(-cameraDistance,0,0);
            //Vector3 offset = new Vector3(center.y, 0, -center.x).normalized * cameraDistance;
            //targetPosition = offset + new Vector3(0,yPosition);
            //targetPosition = new Vector3(center.x, yPosition, center.z);
            //transform.LookAt(center);
            //transform.position += (targetPosition - transform.position) * easing;
            //float angle = Mathf.Atan(yPosition / cameraDistance);
            //float angle = Mathf.Atan(offset.x / yPosition);
            //transform.eulerAngles = new Vector3 (angle/UtilityFunctions.RADTODEG, 0, 0);
            //transform.eulerAngles = new Vector3(angle, 0, 0);
            //transform.LookAt(center);
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
