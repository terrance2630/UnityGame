using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxController : MonoBehaviour
{
    [SerializeField] private Animator boxAnimatorController;

    public GameObject player;

    public GameObject box;

    public GameObject cardPiece;

    public Inventory inventory;

    public CardManage cManage;

    int currentCard = 0;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player)
        {
            boxAnimatorController.SetBool("Trig", true);
            Inventory.cardPieces[box.GetComponent<CardPieceScript>().cardPieceNumber]=true;
            Destroy(cardPiece, 1.5f);

            currentCard = inventory.CardNumber();

            cManage.PlusBox(currentCard);

        }
    }
}
