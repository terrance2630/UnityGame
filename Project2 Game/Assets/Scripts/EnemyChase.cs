using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.AI;

 public class EnemyChase : MonoBehaviour
 {
 
     public Transform Player;
     public int MoveSpeed = 4;
     public int MaxDist = 10;
     public int MinDist = 5;
     private NavMeshAgent enemy;
     
 
     void Start()
     {
         enemy = GetComponent<NavMeshAgent> ();
     }
 
     void Update()
     {  
         
        // transform.LookAt(Player);

        // if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        // {

        //     transform.position += transform.forward * MoveSpeed * Time.deltaTime;



        //     if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        //     {
        //         //Here Call any function U want Like Shoot at here or something
        //     }

        // }
        enemy.SetDestination(Player.position);
         
     }
 }