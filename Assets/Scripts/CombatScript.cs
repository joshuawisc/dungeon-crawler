using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Rigidbody rb;
    public Collider meleeHitbox;
    public GameObject weapon;
    public BaseStats stats;
    public ParticleSystem psystem;
    public float dashSpeed = 100f;
    public float maxDashDist = 7f;
    public float dashDist = 7f;


    private float attackTimer = 0f; // To implement per weapon attack times
    private int attacked = 0; // To prevent holding attack
    private int dashed = 0;
    private int abilityPressed = 0;
    private float abilityTime = 0f;
    private float abilityCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float setMaxDash = 7f;
        rb = GetComponent<Rigidbody>();
        stats = new RogueStats();
        meleeHitbox = weapon.GetComponent<Collider>();
        psystem = GetComponentInChildren<ParticleSystem>();
        psystem.Stop();
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
                FindObjectOfType<AudioManager>().Play("Swing");

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
                        FindObjectOfType<AudioManager>().Play("HitEnemy");

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

            if (Input.GetAxisRaw("Fire2") > 0 && abilityCooldown == 0)
            {
                if (abilityTime <= 5)
                {
                    abilityPressed = 1;
                    abilityTime += Time.deltaTime;
                    psystem.Play();
                    Debug.Log("Ability");
                    Collider[] collisions = Physics.OverlapBox(meleeHitbox.bounds.center, meleeHitbox.bounds.extents, meleeHitbox.transform.rotation, LayerMask.GetMask("Hitbox"));
                    foreach (Collider col in collisions)
                    {
                        if (col.transform.parent != null && col.transform.parent == transform)
                        {
                            continue;
                        }

                        if (col.gameObject.GetComponent<EnemyController>().stats.className == "Enemy")
                        {

                            col.gameObject.GetComponent<EnemyController>().stats.TakeDamage(51); //TODO: Add weapon damage
                            Debug.Log("Ability hit: " + col.name + "for 1 damage");

                        }

                    } 
                } else
                {
                    psystem.Stop();
                }
            } else
            {
                if (abilityTime > 0)
                {
                    abilityCooldown = abilityTime;
                    if (abilityCooldown > 5)
                        abilityCooldown = 5;
                    if (abilityCooldown < 3)
                        abilityCooldown = 3;
                } else
                {
                    abilityCooldown -= Time.deltaTime;
                    if (abilityCooldown < 0)
                        abilityCooldown = 0;
                }
                Debug.Log(abilityCooldown);
                abilityPressed = 0;
                abilityTime = 0;
                psystem.Stop();
            }
        }
        Physics.IgnoreLayerCollision(8, 8, false);
        if (dashDist < maxDashDist)
        {
            Physics.IgnoreLayerCollision(8, 8, true);  // To pass through enemies while dashing
            float dash = Mathf.Abs(Input.GetAxis("Horizontal")) * dashSpeed * Time.deltaTime;
            dashDist += dash;
            transform.Translate(dash, 0, 0);
            // rb.AddForce(new Vector3(Mathf.Sign(Input.GetAxis("Horizontal")) * dashSpeed, 0, 0), ForceMode.Impulse);
            //Debug.Log(dash);
            dashed = 1;
            //Debug.Log("dashed " + dash.ToString());
        }
    }

    
}
