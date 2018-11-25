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
        if(Input.GetKeyDown(KeyCode.F) == true)
        {
            Switch();
        }
	}

    private void OnGUI()
    {
        if (switching)
        {
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
}
