using UnityEngine;

public class RagdollWalker : MonoBehaviour
{
    [Header("Piernas")]
    public ConfigurableJoint leftThigh;
    public ConfigurableJoint rightThigh;

    [Header("Cuerpo")]
    public Rigidbody hips;

    [Header("Parámetros de caminata")]
    public float walkSpeed = 0f;        // controlado por input
    public float baseStepAngle = 30f;   // amplitud base del paso
    public float moveSpeed = 3f;        // velocidad base de desplazamiento
    public float rotationSpeed = 200f;  // grados por segundo

    private float horizontal;
    private float vertical;

    public void SetInput(float h, float v)
    {
        horizontal = h;
        vertical = v;
    }

    void FixedUpdate()
    {
        // Detectar velocidad real del hips
        float speed = hips.velocity.magnitude;

        // Animación de piernas si hay input o si el hips se está moviendo
        if (speed > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            float frequency = walkSpeed * (speed > 0.1f ? speed : 1f);
            float amplitude = baseStepAngle * Mathf.Clamp(speed, 1f, 3f);

            float t = Time.time * frequency;

            float leftAngle = Mathf.Sin(t) * amplitude;
            SetJointTarget(leftThigh, leftAngle);

            float rightAngle = Mathf.Sin(t + Mathf.PI) * amplitude;
            SetJointTarget(rightThigh, rightAngle);
        }

        // Movimiento estable hacia adelante/atrás
        if (Mathf.Abs(vertical) > 0.1f)
        {
            // Tomar solo el plano XZ del forward del hips
            Vector3 forward = hips.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 moveDir = forward * vertical;

            Vector3 targetPos = hips.position + moveDir * (moveSpeed * walkSpeed) * Time.fixedDeltaTime;
            hips.MovePosition(targetPos);
        }

        // Rotación suave izquierda/derecha
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            Quaternion targetRot = Quaternion.Euler(0, horizontal * rotationSpeed * Time.fixedDeltaTime, 0) * hips.rotation;
            hips.MoveRotation(targetRot);
        }
    }

    void SetJointTarget(ConfigurableJoint joint, float angle)
    {
        Quaternion target = Quaternion.Euler(angle, 0, 0);
        joint.targetRotation = target;

        JointDrive drive = joint.slerpDrive;
        drive.positionSpring = 3000f;
        drive.positionDamper = 200f;
        drive.maximumForce = 1000f;
        joint.slerpDrive = drive;

        joint.rotationDriveMode = RotationDriveMode.Slerp;
    }
}
