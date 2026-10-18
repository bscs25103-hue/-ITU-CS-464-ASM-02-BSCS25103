using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(-7, 4, 0);
    [SerializeField] float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 wanted = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position, wanted, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
