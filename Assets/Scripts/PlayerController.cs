using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public float maxSpeed = 6f;
    public LayerMask groundLayer;
    public float jumpForce = 1200.0f;
    public CapsuleCollider collider;
    public float distToGround;
    public float distToSides;
    public float gravity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        distToGround = collider.bounds.extents.y;
        distToSides = collider.bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
        Debug.Log("" + Input.GetAxis("Vertical"));

        if (IsGrounded())
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.AddForce(Vector3.up * jumpForce);
            }

        
        }
        rb.AddForce(Vector3.down * gravity, ForceMode.VelocityChange);

        // rb.velocity.y -= gravity * Time.deltaTime;

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
    }
}
