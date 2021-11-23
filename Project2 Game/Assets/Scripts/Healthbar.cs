using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Text;


public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public Text healthText;

    public void SetMaxHealth (float health)
    {
        slider.maxValue = health;
        slider.value = health;

        healthText.text = health.ToString() + "%";
    }
    
    public void SetHealth (float health)
    {
        slider.value = health;

        healthText.text = Convert.ToInt32(health).ToString() + "%";

    }
}
