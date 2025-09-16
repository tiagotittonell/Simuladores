using UnityEngine;

public class RootMover : MonoBehaviour
{
    public Rigidbody rootBody;
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; // grados por segundo

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        Vector3 moveInput = new Vector3(h, 0, v).normalized;

        if (moveInput.magnitude > 0.1f)
        {
            // Dirección de movimiento
            Vector3 moveDir = transform.TransformDirection(moveInput);

            // Movimiento estable
            Vector3 targetPos = rootBody.position + moveDir * moveSpeed * Time.fixedDeltaTime;
            rootBody.MovePosition(targetPos);

            // Rotación suave hacia dirección de movimiento
            Quaternion targetRot = Quaternion.LookRotation(moveDir, Vector3.up);
            rootBody.MoveRotation(Quaternion.RotateTowards(rootBody.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));
        }
    }
}
