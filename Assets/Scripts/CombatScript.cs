using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Rigidbody rb;
    public Collider meleeHitbox;
    public GameObject weapon;
    public BaseStats stats;
    public float dashSpeed = 30f;
    public float maxDashDist = 5f;
    public float dashDist = 30f;

    private float attackTimer = 0f; // To implement per weapon attack times
    private int attacked = 0; // To prevent holding attack
    private int dashed = 0; 

    // Start is called before the first frame update
    void Start()
    {
        float setMaxDash = 30f;
        rb = GetComponent<Rigidbody>();
        stats = new RogueStats();
        meleeHitbox = weapon.GetComponent<Collider>();
        dashDist = setMaxDash;
        maxDashDist = setMaxDash;

    }

// Update is called once per frame
void FixedUpdate()
    {
        weapon.SetActive(false);

        attackTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (attackTimer >= 0.01 && attacked == 0)
            {
                attacked = 1;
                weapon.SetActive(true);
                attackTimer = 0f;
                Collider[] collisions = Physics.OverlapBox(meleeHitbox.bounds.center, meleeHitbox.bounds.extents, meleeHitbox.transform.rotation, LayerMask.GetMask("Hitbox"));
                foreach (Collider col in collisions)
                {
                    if (col.transform.parent != null && col.transform.parent == transform)
                    {
                        continue;
                    }

                    if (col.gameObject.GetComponent<EnemyController>().stats.className == "Enemy")
                    {
                        col.gameObject.GetComponent<EnemyController>().stats.TakeDamage(stats.strength); //TODO: Add weapon damage
                        Debug.Log("hit: " + col.name + "for 10 damage");

                    }

                }
            }
        } else
        {
            attacked = 0;
        }

        if (stats.className == "Rogue")
        {
            if (Input.GetAxisRaw("Fire3") > 0)
            {
                if (dashed == 0 && dashDist >= maxDashDist) 
                {
                    // transform.Translate(Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime * speed, 0, 0);
                    dashed = 1;
                    dashDist = 0;
                   
                }
            } else
            {
                dashed = 0;
            }
        }
        Physics.IgnoreLayerCollision(8, 8, false);
        if (dashDist < maxDashDist)
        {
            Physics.IgnoreLayerCollision(8, 8, true);
            float dash = Mathf.Abs(Input.GetAxis("Horizontal")) * dashSpeed * Time.deltaTime;
            dashDist += dash;
            transform.Translate(dash, 0, 0);
            // rb.AddForce(new Vector3(Mathf.Sign(Input.GetAxis("Horizontal")) * dashSpeed, 0, 0), ForceMode.Impulse);
            Debug.Log(dash);
            dashed = 1;
            Debug.Log("dashed " + dash.ToString());
        }
    }

    
}
