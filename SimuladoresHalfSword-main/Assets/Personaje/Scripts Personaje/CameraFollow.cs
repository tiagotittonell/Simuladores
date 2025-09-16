using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // PlayerRoot
    public Vector3 offset = new Vector3(0, 3, -6);
    public float followSpeed = 5f;
    public float rotateSpeed = 120f;

    float yaw;   // rotaci�n horizontal
    float pitch; // rotaci�n vertical

    void LateUpdate()
    {
        if (!target) return;

        // Rotaci�n con el mouse
        yaw += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Posici�n de la c�mara detr�s del target
        Vector3 desiredPos = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        // Mirar al target
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
