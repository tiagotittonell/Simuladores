using UnityEngine;

public class RagdollBalancer : MonoBehaviour
{
    public Rigidbody hips;
    public float uprightTorque = 1200f;   // más bajo que antes
    public float forwardLean = 10f;       // inclinación hacia adelante en grados

    void FixedUpdate()
    {
        // Mantener hips con inclinación hacia adelante
        Quaternion targetRotation = Quaternion.Euler(forwardLean, hips.rotation.eulerAngles.y, 0);
        Quaternion delta = targetRotation * Quaternion.Inverse(hips.rotation);

        delta.ToAngleAxis(out float angle, out Vector3 axis);
        if (angle > 180f) angle -= 360f;

        hips.AddTorque(axis * angle * uprightTorque * Time.fixedDeltaTime);


    }
}
