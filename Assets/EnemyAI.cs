using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            agent.SetDestination(player.transform.position);

            if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                if(Time.time - lastAttackTime >= attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

}
