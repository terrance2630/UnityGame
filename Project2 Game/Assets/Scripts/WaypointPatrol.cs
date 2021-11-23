using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;

    


    public ParticleSystem BSA;
    public ParticleSystem BSA2;


    // Player Chasing
    public Transform Player;
    public float detectDistance = 1.0f;
    public float damageDistance = 0.5f;
    public float enemyMaxSpeed =  6.0f;
    public float enemyMinSpeed = 2.0f;

    public HealthManager playerHealth;
    public float damageAmount = 0.05f;
    

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        
    }

    
    void Update()
    {   
        navMeshAgent.speed = Random.Range(enemyMinSpeed, enemyMaxSpeed);
        if (Vector3.Distance(transform.position, Player.position) > detectDistance){
            // If not close enough
            if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance){
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
        }
        else
        {      
            // Close enough to follow
            // Close enough to attack
            transform.LookAt(Player);
            if(Vector3.Distance(transform.position, Player.position) <= damageDistance)
            {
                BSA.Play();
                BSA2.Play();
                playerHealth.ApplyDamage(damageAmount);
            }
            else
            {
                navMeshAgent.SetDestination(Player.position);
            }
            
        }
    }
}
