using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManage : MonoBehaviour
{

    public CountPiece countpiece;
    
    void Start()
    {
        countpiece.SetCard(0);
    }

    public void PlusBox(int currentCard)
    {
        countpiece.SetCard(currentCard);
    }

}
