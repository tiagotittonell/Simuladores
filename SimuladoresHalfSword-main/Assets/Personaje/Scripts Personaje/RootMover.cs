using UnityEngine;

public class RootMover : MonoBehaviour
{
    public Rigidbody rootBody;
    public float moveForce = 300f;
    public float turnSpeed = 5f;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        Vector3 move = new Vector3(h, 0, v).normalized;

        if (move.magnitude > 0.1f)
        {
            // Empuje recto en la dirección actual del Root
            rootBody.AddForce(transform.forward * v * moveForce);

            // Rotación hacia izquierda/derecha
            if (h != 0)
            {
                Quaternion turn = Quaternion.Euler(0, h * turnSpeed, 0);
                rootBody.MoveRotation(rootBody.rotation * turn);
            }
        }
    }
}
