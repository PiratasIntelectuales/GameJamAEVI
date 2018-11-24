using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float timeToFade = 2.0f;
    public GameObject directLight;
    public float rotSpeed = 1.0f;
    public float yDayRot = 220.0f;
    public float yDayNight = 90.0f;
    public Vector3 dayPos;
    public Vector3 nightPos;
    public Vector3 nightRot;

    private float yRot = 0.0f;
    private int state = 0; //0 orthogonal, 1 perspective
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
        directLight.transform.rotation = Quaternion.Euler(74, yRot, -340);
        yRot += rotSpeed * Time.deltaTime;

        if(yRot > yDayNight && yRot < yDayRot && dayCycle == 0)
        {
            dayCycle = 1;
            Switch();
        }

        if(yRot > yDayRot && dayCycle == 1)
        {
            dayCycle = 0;
            Switch();
        }

        if(yRot >359.0f)
        {
            yRot = 0;
        }
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
                    if (state == 0)
                    {
                        state = 1;
                        GetComponent<Camera>().orthographic = false;
                        transform.position = nightPos;
                        transform.rotation = Quaternion.Euler(nightRot);
                    }
                    else if (state == 1)
                    {
                        state = 0;
                        GetComponent<Camera>().orthographic = true;
                        transform.position = dayPos;
                        transform.rotation = Quaternion.Euler(0, 0, 0);
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
