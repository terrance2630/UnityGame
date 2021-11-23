using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPrinciples : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public HealthManager healthManager;
    public float damage = 10;
    public AudioSource audioData;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform == Player)
        {
            healthManager.ApplyDamage(damage);
            
            audioData.Play(0);
        }

        if(other.tag== "Ceilings")
        {
            Destroy(gameObject);
        }
    }
}
