using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 30f;
    public float maxSpeed = 30f;
    public LayerMask groundLayer;
    public float jumpForce = 48.0f;
    public CapsuleCollider collider;
    public float distToGround;
    public float distToSides;
    public float gravity = 1.0f;
    public float health = 100.0f;
    public bool rightfacing = true;

    public bool LTActive = false;
    public bool RTActive = false;
    public int TurnTicker = 0;
    public Collider meleeHitbox;
    public int TURN_BUFFER = 18;

    public int jumps = 2;
    public int doublejumpbuffer = 100;
    public int jumprefillbuffer = 20;
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
        
        
        

        // Code that reads left right input    
        if(!LTActive && !RTActive)
        {
            if (rightfacing && Input.GetAxis("Horizontal") < 0)
            {
                /*
                transform.Rotate(Vector3.up, 180.0f);
                rightfacing = false;
                */
                LTActive = true;
                TurnTicker += TURN_BUFFER;
                rightfacing = false;
            }
            else if (!rightfacing && Input.GetAxis("Horizontal") > 0)
            {
                /*
                transform.Rotate(Vector3.up, 180.0f);
                rightfacing = true;
                */
                RTActive = true;
                TurnTicker += TURN_BUFFER;
                rightfacing = true;
            }
            transform.Translate(Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            float turnInterval = (180.0f / TURN_BUFFER);
            transform.Rotate(Vector3.up, turnInterval);
            TurnTicker--;
            if(TurnTicker == 0)
            {
                LTActive = false;
                RTActive = false;
            }
        }
        


        //Attack Button Input
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


        //Single Jump Input
        if (IsGrounded())
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumps--;
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
