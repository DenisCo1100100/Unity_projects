using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float speedRotat = 0.1f;
    private Vector2 angle;
    private float clampAngle = 90f;
    private TouchField field;
    private void Start()
    {
        field = GameObject.FindGameObjectWithTag("ToutchField").GetComponent<TouchField>();
    }

    private void LateUpdate()
    { 
        angle.x -= field.TouchDist.y * speedRotat;
        angle.y += field.TouchDist.x * speedRotat;

        angle.x = Mathf.Clamp(angle.x, -clampAngle, clampAngle);

        Quaternion rot = Quaternion.Euler(angle.x, angle.y, 0.0f);
        transform.rotation = rot;
    }
}