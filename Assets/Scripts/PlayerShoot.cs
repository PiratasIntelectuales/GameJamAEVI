using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float axis_h = Input.GetAxisRaw("Secondary_Horizontal");
        float axis_v = Input.GetAxisRaw("Secondary_Vertical");

        if (axis_h != 0.0f  || axis_v != 0.0f)
        {
            float angle = Mathf.Atan2(axis_v, axis_h);
            Quaternion tmp = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.up);
            transform.rotation = tmp;
        }

       
    }
}
