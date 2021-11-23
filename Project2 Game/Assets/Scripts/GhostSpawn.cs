using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public GameObject itemToSpread;
    public Transform player;
    public int extra_per_ten_second = 2;    
    
    public float spawn_time_gap = 10.0f;
    public float duration_time = 8.0f;
    public float spawn_distance = 5.0f;

    float next_spawn_time;
    float next_increase_time;
    int numItemToSpawn = 1;

    void Start()
    {
        next_spawn_time = Time.time+spawn_time_gap;
        next_increase_time = Time.time+spawn_time_gap*2;    
    }

    void SpawnItem()
    {
        // Get player's position.
        float x = player.position.x;
        float y = player.position.y;
        float z = player.position.z;
        
        // Create a rule for clone's position.
        Vector3 randPosition = new Vector3(Random.Range(x-spawn_distance, x+spawn_distance),
                                            Random.Range(y, y+spawn_distance/2), 
                                            Random.Range(z, z+spawn_distance+2));
        
        //Clone the object with given position.
        GameObject clone = Instantiate(itemToSpread, randPosition, Quaternion.identity);
        clone.tag = "Clone";    
    }

    void Update() 
    {
        var clones = GameObject.FindGameObjectsWithTag("Clone");
        
        // Let the ghost disappear.
        foreach(var clone in clones){
            Destroy(clone, duration_time);
        }

        //Spawn item for every 'spawn_time_gap'.
        if(Time.time > next_spawn_time)
        {
            for (var i = 0; i < numItemToSpawn; i++)
            {
                SpawnItem();
            }
            next_spawn_time += spawn_time_gap;
        }

        // Increase the amount of ghost after certain amount of time
        if(Time.time > next_increase_time)
        {
            numItemToSpawn += extra_per_ten_second;
            next_increase_time += spawn_time_gap*1.5f;
        }        
    }

    
}
