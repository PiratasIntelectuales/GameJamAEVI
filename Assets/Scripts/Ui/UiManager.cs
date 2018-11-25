using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

  //  public GameObject canvas;
    Animator Uianimator;

    public GameObject shopManager;

    public float Points; //puntos que tiene el jugador
    public float LimitPoints; // limite de puntos para ganar

    void Start()
    {
        Uianimator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            GoStopMenu();
        }
        if (Input.GetKey("l")) //Must be deleted
        {
            FinishDay();
        }
        if (LimitPoints==Points) //cuando los puntos iguala o supera pasa a la pantalla de victoria
        {
            Win();
        }

    }
   public void PushQuit()
    {
        Uianimator.SetBool("ToQuit", true);
        Application.Quit();
    }

    public void EnableDisable(GameObject GO)
    {
        GO.SetActive(!GO.activeSelf);
    }

    public void NextDay()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("FinishedDay", false);
    }

    public void FinishDay()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("FinishedDay", true);
    }

    public void Play()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("InStartMenu", false);
    }

    public void Resume()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("InStartMenu", false);
        Uianimator.SetBool("InStopMenu", false);
    }

    public void Win()
    {
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("Win", true);
        Uianimator.SetBool("Lose", false);

    }

    public void Lose()
    {
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("Win", false);
        Uianimator.SetBool("Lose", true);

    }

    public void GoStartMenu()
    {
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("InStartMenu", true);
        Uianimator.SetBool("InStopMenu", false);
        Uianimator.SetBool("ToQuit", false);
        Uianimator.SetBool("Win", false);
        Uianimator.SetBool("Lose", false);

    }

    public void GoStopMenu()
    {
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("InStartMenu", false);
        Uianimator.SetBool("InStopMenu", true);
        Uianimator.SetBool("ToQuit", false);
        Uianimator.SetBool("Win", false);
        Uianimator.SetBool("Lose", false);

    }

    public void GoShop()
    {
        Uianimator.SetBool("Earned", true);
    }

}
