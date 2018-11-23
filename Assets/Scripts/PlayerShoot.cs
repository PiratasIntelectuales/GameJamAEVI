using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization
    public float rotation_treeshold = 0.9f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 axis = new Vector2(Input.GetAxisRaw("Secondary_Horizontal"), -Input.GetAxisRaw("Secondary_Vertical"));

        if (axis.magnitude > rotation_treeshold)
        {
            float angle = (Mathf.Atan2(axis.x, axis.y) * Mathf.Rad2Deg);
            Quaternion tmp = Quaternion.AngleAxis(angle , Vector3.up);
            transform.rotation = tmp;
        }      
    }
}
