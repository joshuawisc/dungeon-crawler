using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour

{

    public float lookRadius = 10f;
    public float turnSpeed = 100f;

    public BaseStats stats = new EnemyStats();
    public Text enemyHealthLabel;

    Vector3 startingPos;
    Vector3 patrolPos;

    GameObject target;
    Transform targetTransform;
    BaseStats targetStats;
    NavMeshAgent agent;


    float attackTimer = 0f; //Prevent attacks every frame
    


    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("Player");
        targetTransform = target.transform;
        targetStats = targetTransform.GetComponent<CombatScript>().stats;
        agent = GetComponent<NavMeshAgent>();
        startingPos = transform.position;
        patrolPos = transform.position;
        enemyHealthLabel = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 healthPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthPos.y += 40;
        enemyHealthLabel.transform.position = healthPos;
        enemyHealthLabel.text = stats.health + " / " + stats.maxHealth;

        float distance = Vector3.Distance(targetTransform.position, transform.position);
        attackTimer += Time.deltaTime;

        agent.speed = 3.5f;
        if (distance <= lookRadius)
        {
            agent.speed = 6f;
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending && attackTimer >= 3f)  //TODO: Change based on stats?
            {
                targetStats.TakeDamage(stats.strength); //TODO: add weapon damage
                attackTimer = 0f;
                Debug.Log("attack");
            }
            else
            {
                agent.SetDestination(targetTransform.position);
                Debug.Log("Follow");
                FaceTarget();
            }
        }
        else
        {
            //patrolPos.x += patrolDir * Time.deltaTime * 100;
            //agent.SetDestination(patrolPos);
            //Debug.Log("" + patrolPos.x);
            //TODO: Change destination positions;
            //Debug.Log("Patrol");
            Debug.Log(agent.remainingDistance.ToString());
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (patrolPos.x == startingPos.x - 5)
                    patrolPos.x = startingPos.x + 25;
                else
                    patrolPos.x = startingPos.x - 5;
                agent.SetDestination(patrolPos);
            }
            /**
            if (transform.position.x >= startingPos.x + 20)
            {
                Debug.Log("Go Home");
                Vector3 newDir = startingPos;
                newDir.x -= 5;
                agent.SetDestination(newDir);
            } else if (transform.position.x <= startingPos.x)
            {
                Debug.Log("Go Patrol");
                Vector3 newDir = startingPos;
                newDir.x +=25;
                agent.SetDestination(newDir);
            }
            **/
        }

        if (stats.health <= 0)
            Destroy(gameObject);
    }

    void FaceTarget()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime*turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
