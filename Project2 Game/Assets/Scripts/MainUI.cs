using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HomePage()
    {
        SceneManager.LoadScene("Start Menu");
    }
    // Update is called once per frame
    
}
