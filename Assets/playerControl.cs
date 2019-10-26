using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 3f;
    public float maxSpeed = 6f;
    public LayerMask groundLayer;
    public float jumpForce = 2f;
    public CapsuleCollider collider;
    public float distToGround;
    public float distToSides;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        distToGround = collider.bounds.extents.y;
        distToSides = collider.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -maxSpeed)
            {
                rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x< maxSpeed)
            {
                rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
        }

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
