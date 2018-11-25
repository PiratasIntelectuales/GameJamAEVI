using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTimeSlider : MonoBehaviour {

    public CameraController camera_contrroller;
    Slider my_slider;

	// Use this for initialization
	void Start () {
        my_slider = GetComponent<Slider>();

        my_slider.maxValue = camera_contrroller.GetTotalTime();
	}
	
	// Update is called once per frame
	void Update () {

        my_slider.value = camera_contrroller.GetCurrentTime();

	}
}
