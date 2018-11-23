using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float move_horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float move_vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        if(move_horizontal != 0.0 || move_vertical != 0.0f)
            transform.Translate(new Vector3(move_horizontal, 0.0f, move_vertical), Space.World);
    }
}
