using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class MouseManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool initialized = false;
    public Slider mouseSensitivitySlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            mouseSensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
        }
        initialized = true;
    }

    public void SetMouseSensitivity(float val)
    {
        if (initialized && Application.isPlaying) return;

        PlayerPrefs.SetFloat("Sensitivity", val);

    }
}