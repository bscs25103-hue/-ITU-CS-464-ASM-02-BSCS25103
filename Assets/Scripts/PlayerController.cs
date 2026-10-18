using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 1.8f;
    [SerializeField] Transform feetPosition;
    [SerializeField] float checkRadius = 0.2f;
    [SerializeField] LayerMask groundMask;

    Rigidbody rb;
    Vector3 moveInput;
    bool isGrounded;
    bool jumpQueued;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveInput = new Vector3(moveX, 0f, moveZ);
        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput.Normalize();
        }

        if (feetPosition != null)
        {
            isGrounded = Physics.CheckSphere(feetPosition.position, checkRadius, groundMask);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(moveInput.x * speed, currentVelocity.y, moveInput.z * speed);

        if (jumpQueued)
        {
            float gravity = -Physics.gravity.y;
            float v0 = Mathf.Sqrt(2f * gravity * jumpHeight);

            rb.AddForce(Vector3.up * rb.mass * v0, ForceMode.Impulse);

            jumpQueued = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (feetPosition != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(feetPosition.position, checkRadius);
        }
    }
}
