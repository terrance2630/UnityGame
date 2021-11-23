using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool[] cardPieces = new bool [3];

    private int currentCard = 0;

    void Start() {
        cardPieces = new bool[3];
    }
    
    public int CardNumber()
    {
        currentCard = 0;
        foreach (bool key in Inventory.cardPieces)
        {
            if(key == true)
            {
                currentCard+=1;
            }
        }
        return currentCard;
    }
}
