using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float timeToFade = 2.0f;

    public GameObject dayStuff;
    public GameObject nightStuff;
    public List<GameObject> dayPots;
    public List<GameObject> nightPots;
    public GameObject dayCam;
    public GameObject nightCam;

    private int dayCycle = 0; //0 day, 1 night
    public Texture blackTexture;
    private bool switching = false;
    private bool fadingOut = false;
    private bool fadingIn = false;
    private float alphaFadeOut = 0.0f;
    private float alphaFadeIn = 1.0f;

    private float day_night_timer = 0.0f;
    public bool start_counting = false;
    public float day_time_duration = 120.0f;  //2 minutos
    public float night_time_duration = 300.0f;//5 minutos
    public GameObject player_pj;
    public UiManager ui_manager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //directLight.transform.rotation = Quaternion.Euler(74, yRot, -340);
        //yRot += rotSpeed * Time.deltaTime;

        //if(yRot > yDayNight && yRot < yDayRot && dayCycle == 0)
        //{
        //    dayCycle = 1;
        //    Switch();
        //}

        //if(yRot > yDayRot && dayCycle == 1)
        //{
        //    dayCycle = 0;
        //    Switch();
        //}

        //if(yRot >359.0f)
        //{
        //    yRot = 0;
        //}
        if(start_counting)
        {
            if(dayCycle == 0)//day
            {
                if (day_night_timer >= day_time_duration)
                {

                    Switch();

                    FindObjectOfType<AudioManager>().changeBSO(0);
                }
            }

            if (dayCycle == 1)//night
            {
                bool success = false;
                for (int i = 0; i < nightPots.Count; i++)
                {
                    Transform[] tempTrans = nightPots[i].GetComponentsInChildren<Transform>();
                    foreach(Transform plant in tempTrans)
                    {
                        if (plant.gameObject.CompareTag("Pot") == false)
                        {
                            success = true;
                            break;
                        }
                    }
                }
                if(success == false)
                {
                    ui_manager.Lose();
                }
                if (day_night_timer >= night_time_duration)
                {
                    //Activate Shop menu
                    ui_manager.FinishDay();
                }
            }

            day_night_timer += Time.deltaTime;
        }
        

        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            Switch();
        }
	}

    public void SetCounter(bool value)
    {
        start_counting = value;
    }

    public void RestartCounter()
    {
        day_night_timer = 0.0f;
    }

    private void OnGUI()
    {
        if (switching)
        {
            start_counting = false;

            if (alphaFadeOut < 1.0f && fadingOut == true)
            {
                alphaFadeOut += Mathf.Clamp01(Time.deltaTime / timeToFade);
                GUI.color = new Color(0, 0, 0, alphaFadeOut);
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
            }

            else if (alphaFadeIn > 0.0f)
            {
                if (fadingIn == false)
                {
                    fadingIn = true;
                    fadingOut = false;
                    if (dayCycle == 0)
                    {
                        dayCycle = 1;
                        nightCam.SetActive(true);
                        nightStuff.SetActive(true);
                        player_pj.SetActive(true);
                        player_pj.GetComponent<PlayerShoot>().SetPlayer();

                        Debug.Log("OSTIAS YA");

                        for (int i = 0; i < dayPots.Count; i++)
                        {
                            Transform[] tempTrans = dayPots[i].GetComponentsInChildren<Transform>();
                            foreach (Transform tempPlant in tempTrans)
                            {
                                if (tempPlant.gameObject != dayPots[i])
                                {
                                    tempPlant.SetParent(nightPots[i].transform, false);
                                    break;
                                }
                            }
                        }
                        dayCam.SetActive(false);
                        dayStuff.SetActive(false);
                        
                    }
                    else if (dayCycle == 1)
                    {
                        dayCycle = 0;
                        dayCam.SetActive(true);
                        dayStuff.SetActive(true);
                        for (int i = 0; i < nightPots.Count; i++)
                        {
                            Transform[] tempTrans = nightPots[i].GetComponentsInChildren<Transform>();
                            foreach (Transform tempPlant in tempTrans)
                            {
                                if (tempPlant.gameObject != nightPots[i])
                                {
                                    tempPlant.SetParent(dayPots[i].transform, false);
                                    break;
                                }
                            }
                        }
                        nightCam.SetActive(false);
                        nightStuff.SetActive(false);
                        player_pj.SetActive(false);
                    }
                }
                alphaFadeIn -= Mathf.Clamp01(Time.deltaTime / timeToFade);
                GUI.color = new Color(0, 0, 0, alphaFadeIn);
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
            }
            else
            {
                switching = false;
                fadingIn = false;
                start_counting = true;
                day_night_timer = 0.0f;
            }
        }
    }

    public void Switch()
    {
        switching = true;
        fadingOut = true;
        alphaFadeOut = 0.0f;
        alphaFadeIn = 1.0f;
    }

    public float GetTotalTime()
    {
        return (day_time_duration + night_time_duration);
    }

    public float GetCurrentTime()
    {
        float ret = day_night_timer;
        if (dayCycle == 1)
            ret += day_time_duration;
        return ret;
    }
}
