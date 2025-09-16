using UnityEngine;

public class RagdollMover : MonoBehaviour
{
    public Rigidbody hips;
    public float moveSpeed = 2f;

    void FixedUpdate()
    {
        // Si presiono W, mover hacia adelante
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forward = hips.transform.forward;   // direcci�n del hips
            forward.y = 0;                              // evitar inclinaci�n
            forward.Normalize();

            Vector3 targetPos = hips.position + forward * moveSpeed * Time.fixedDeltaTime;
            hips.MovePosition(targetPos);
        }
    }
}
