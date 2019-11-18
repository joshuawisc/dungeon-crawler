using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Rigidbody rb;
    public Collider meleeHitbox;
    public GameObject weapon;
    public BaseStats stats;

    private float attackTimer = 0f; // To implement per weapon attack times
    private int attacked = 0; // To prevent holding attack

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = new RogueStats();
        meleeHitbox = weapon.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        weapon.SetActive(false);

        attackTimer += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (attackTimer >= 0.5 && attacked == 0)
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
    }
}
