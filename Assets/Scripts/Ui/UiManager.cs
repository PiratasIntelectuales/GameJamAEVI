using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {


    private int days=1;
    public int maxDays =5;

  //  public GameObject canvas;
    Animator Uianimator;

    public GameObject shopManager;

    public float Points; //puntos que tiene el jugador
    public float LimitPoints; // limite de puntos para ganar

    public CameraController day_night_cycle_manager;

    void Start()
    {
        Uianimator = GetComponent<Animator>();
        FindObjectOfType<AudioManager>().LazerOFF();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            GoStopMenu();
        }



        if (maxDays == days)
        {
            Win();
        }

    }

    public void AddDay()
    {
        days++;
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
        AddDay();
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("FinishedDay", false);
        Uianimator.SetBool("Earned", false);

    }

    public void FinishDay()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("FinishedDay", true);
         Uianimator.SetBool("2part", false);
        FindObjectOfType<AudioManager>().LazerOFF();
    }

    public void Play()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("InStartMenu", false);
        Uianimator.SetBool("2part", false);
    }

    public void Resume()
    {
        Uianimator.SetBool("Playing", true);
        Uianimator.SetBool("InStartMenu", false);
        Uianimator.SetBool("InStopMenu", false);

        //Stop counting day/night time
        day_night_cycle_manager.SetCounter(true);

        FindObjectOfType<AudioManager>().LazerON();
    }

    public void Win()
    {
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("2part", false);
        Uianimator.SetBool("Win", true);
        Uianimator.SetBool("Lose", false);
        FindObjectOfType<AudioManager>().LazerOFF();
    }


    public void Lose()
    {
        FindObjectOfType<AudioManager>().LazerOFF();
        day_night_cycle_manager.SetCounter(false);
        Uianimator.SetBool("2part", false);
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("Win", false);
        Uianimator.SetBool("Lose", true);

    }

    public void GoStartMenu()
    {
        FindObjectOfType<AudioManager>().LazerOFF();
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("InStartMenu", true);
        Uianimator.SetBool("InStopMenu", false);
        Uianimator.SetBool("ToQuit", false);
        Uianimator.SetBool("Win", false);
        Uianimator.SetBool("Lose", false);
        Uianimator.SetBool("2part", false);
    }

    public void GoStopMenu()
    {
        FindObjectOfType<AudioManager>().LazerOFF();
        Uianimator.SetBool("Playing", false);
        Uianimator.SetBool("InStartMenu", false);
        Uianimator.SetBool("InStopMenu", true);
        Uianimator.SetBool("ToQuit", false);
        Uianimator.SetBool("Win", false);
        Uianimator.SetBool("Lose", false);

        //Stop counting day/night time
        day_night_cycle_manager.SetCounter(false);

    }

    public void GoShop()
    {
        Uianimator.SetBool("Earned", true);
        Uianimator.SetBool("2part", false);
        //Stop counting day/night time
        day_night_cycle_manager.SetCounter(false);
    }

}
