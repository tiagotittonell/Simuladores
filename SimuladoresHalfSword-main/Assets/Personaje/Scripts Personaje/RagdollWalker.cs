using UnityEngine;

public class RagdollWalker : MonoBehaviour
{
    [Header("Piernas")]
    public ConfigurableJoint leftThigh;
    public ConfigurableJoint rightThigh;

    [Header("Parámetros de caminata")]
    public float walkSpeed = 0f;      // controlado por input
    public float stepAngle = 30f;     // amplitud del paso

    void FixedUpdate()
    {
        if (walkSpeed > 0.1f)
        {
            float t = Time.time * walkSpeed;

            // Pierna izquierda
            float leftAngle = Mathf.Sin(t) * stepAngle;
            SetJointTarget(leftThigh, leftAngle);

            // Pierna derecha (desfase en PI)
            float rightAngle = Mathf.Sin(t + Mathf.PI) * stepAngle;
            SetJointTarget(rightThigh, rightAngle);
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
