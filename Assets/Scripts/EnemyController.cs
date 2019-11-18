using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour

{

    public float lookRadius = 10f;
    public float turnSpeed = 100f;

    Vector3 startingPos;
    Vector3 patrolPos;

    Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        startingPos = transform.position;
        patrolPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            //Debug.Log("Follow");
            FaceTarget();
        }
        else
        {
            //patrolPos.x += patrolDir * Time.deltaTime * 100;
            //agent.SetDestination(patrolPos);
            //Debug.Log("" + patrolPos.x);
            //TODO: Change destination positions;
            //Debug.Log("Patrol");
            if (transform.position.x >= startingPos.x + 20)
            {
                agent.SetDestination(startingPos);
            } else if (transform.position.x <= startingPos.x)
            {
                Vector3 newDir = startingPos;
                newDir.x +=20;
                agent.SetDestination(newDir);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime*turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
