using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization
    public float rotation_treeshold = 0.9f;

    public float time_between_shots = 0.5f;
    public float shoot_distance = 1000;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Rotate
        Vector2 axis = new Vector2(Input.GetAxisRaw("Secondary_Horizontal"), -Input.GetAxisRaw("Secondary_Vertical"));

        if (axis.magnitude > rotation_treeshold)
        {
            float angle = (Mathf.Atan2(axis.x, axis.y) * Mathf.Rad2Deg);
            Quaternion tmp = Quaternion.AngleAxis(angle , Vector3.up);
            transform.rotation = tmp;
        }

        //Shoot
        Ray tmp_ray = new Ray(transform.position, transform.forward);
        RaycastHit info;

        Physics.Raycast(tmp_ray, out info, shoot_distance);
        //info.transform;


    }
}
