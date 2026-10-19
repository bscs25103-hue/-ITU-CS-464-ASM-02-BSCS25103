using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0f, 4f, -7f);
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] float lookAhead = 0.35f;

    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        if (target == null)
        {
            PlayerController player = FindAnyObjectByType<PlayerController>();
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetVelocity = Vector3.zero;
        Rigidbody targetRb = target.GetComponent<Rigidbody>();

        if (targetRb != null)
        {
            targetVelocity = targetRb.linearVelocity;
            targetVelocity.y = 0f;
        }

        Vector3 wanted = target.position + offset + (targetVelocity * lookAhead);
        transform.position = Vector3.SmoothDamp(transform.position, wanted, ref velocity, smoothTime);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
