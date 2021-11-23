using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Text;


public class CountPiece: MonoBehaviour
{

    public Text cardPiece;

    public void SetCard(int num)
    {
        
        cardPiece.text = num.ToString();
    }


}
