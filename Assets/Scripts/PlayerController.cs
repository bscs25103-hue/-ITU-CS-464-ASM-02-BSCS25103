using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 6f;

    [SerializeField] float jumpBufferTime = 0.15f;
    [SerializeField] float coyoteTime = 0.15f;
    [SerializeField] float fallGravityMultiplier = 2.5f;

    [SerializeField] Transform bodyTransform; 
    [SerializeField] float squashDuration = 0.2f;

    Rigidbody rb;
    bool isGrounded;
    float jumpBufferTimer;
    float coyoteTimer;
    float timeInAir;
    Coroutine activeSquashRoutine;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        if (isGrounded)
        {
            coyoteTimer = coyoteTime;
            timeInAir = 0f;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
            timeInAir += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferTimer = jumpBufferTime;
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        move = Vector3.ClampMagnitude(move, 1f) * speed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        if (jumpBufferTimer > 0f && coyoteTimer > 0f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jumpBufferTimer = -1f;
            coyoteTimer = -1f;
            isGrounded = false;
        }
        if (rb.linearVelocity.y < 0f)
        {
            rb.AddForce(Physics.gravity * (fallGravityMultiplier - 1f), ForceMode.Acceleration);
        }
    }

    void OnCollisionStay(Collision c)
    {
        if (c.GetContact(0).normal.y > 0.5f)
        {
            if (!isGrounded && timeInAir > 0.1f)
            {
                TriggerLandingJuice();
            }
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision c)
    {
        isGrounded = false;
    }

    void TriggerLandingJuice()
    {
        if (bodyTransform == null) return;

        if (activeSquashRoutine != null)
        {
            StopCoroutine(activeSquashRoutine);
        }

        activeSquashRoutine = StartCoroutine(SquashRoutine());
    }

    IEnumerator SquashRoutine()
    {
        float elapsed = 0f;
        while (elapsed < squashDuration)
        {
            float t = elapsed / squashDuration;

            float p = EaseOutBack(t);

            float scaleY = Mathf.LerpUnclamped(0.7f, 1f, p);
            float scaleXZ = Mathf.LerpUnclamped(1.2f, 1f, p);

            bodyTransform.localScale = new Vector3(scaleXZ, scaleY, scaleXZ);

            elapsed += Time.deltaTime;
            yield return null;
        }

        bodyTransform.localScale = Vector3.one;
    }

    float EaseOutBack(float t)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1f;
        return 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);
    }
}
