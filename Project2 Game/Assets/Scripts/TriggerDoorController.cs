using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimatorController;

    public GameObject player;

    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player)
        {
            foreach (bool key in Inventory.cardPieces)
            {
                if(key == false)
                {
                    return;
                }
            }
            
            doorAnimatorController.SetBool("Trigger", true);
            
        }
    }
}
