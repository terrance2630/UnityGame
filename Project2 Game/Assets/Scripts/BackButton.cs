using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scene;
    public GameObject escape;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked(){
        if(scene.activeInHierarchy == true){
            scene.SetActive(false);
            escape.SetActive(true);
        }
        else{
            scene.SetActive(true);
            escape.SetActive(false);
        }
    }
}
