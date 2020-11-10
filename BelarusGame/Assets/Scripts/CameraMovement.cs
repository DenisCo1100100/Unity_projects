using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private float smooth = 5f;
    private Vector3 offset = new Vector3(0, 1f, -1);

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
    }
}
