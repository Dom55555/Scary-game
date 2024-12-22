using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float viewDistance = 12f;
    public float scareDistance = 3f;
    public float patrolDistance = 9f;
    public float patrolInterval = 2f;
    public Gamemanager game;
    public Transform target;

    NavMeshAgent agent;
    Vector3 randomPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(RandomPoint),2f,patrolInterval);
        randomPoint = transform.position;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, patrolDistance);
    }
    void RandomPoint()
    {
        randomPoint += Random.insideUnitSphere * patrolDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, patrolDistance, NavMesh.AllAreas))
        {
            randomPoint = hit.position;
        }
        else
        {
            randomPoint = transform.position;
        }
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position,target.position);
        if (distance < viewDistance && !Gamemanager.PlayerHiding)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(randomPoint);
        }
        if (distance < scareDistance)
        {
            game.gameOver();
            //enabled = false;
        }
    }
    public void difficulty()
    {
        viewDistance+=1.5f;
        patrolDistance += 2;
        transform.GetComponent<NavMeshAgent>().speed += 0.4f;
    }
}
