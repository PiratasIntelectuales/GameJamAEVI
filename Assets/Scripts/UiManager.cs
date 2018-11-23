using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
   public void PushQuit()
    {
        Application.Quit();
    }





}
