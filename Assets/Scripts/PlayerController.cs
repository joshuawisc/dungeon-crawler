using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public float maxSpeed = 6f;
    public LayerMask groundLayer;
    public float jumpForce = 24.0f;
    public CapsuleCollider collider;
    public float distToGround;
    public float distToSides;
    public float gravity = 1.0f;
    public float health = 100.0f;

    public Collider meleeHitbox;
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

        if (Input.GetAxis("Fire1") > 0)
        {
            Collider[] collisions = Physics.OverlapBox(meleeHitbox.bounds.center, meleeHitbox.bounds.extents, meleeHitbox.transform.rotation, LayerMask.GetMask("Hitbox"));
            foreach(Collider col in collisions)
            {
                if (col.transform.parent != null && col.transform.parent.parent != null && col.transform.parent.parent == transform)
                {
                    Debug.Log("continue");
                    continue;
                }
                Debug.Log(col.name);

            }
        }

        if (IsGrounded())
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                health--;
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
