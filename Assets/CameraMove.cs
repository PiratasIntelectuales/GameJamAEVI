using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;
    float smooth_factor = 0.125f;

    public Vector2 top_left;
    public Vector2 bottom_right;

    float y_pos;

	// Use this for initialization
	void Start () {
        y_pos = transform.position.y;
	}

    private void OnEnable()
    {
        y_pos = transform.position.y;
    }

    // Update is called once per frame
    void Update () {

        
	}

    private void LateUpdate()
    {
        Vector3 tmp = player.transform.position;
        tmp.y = 0.0f;

        Vector3 to_player = player.transform.position;
        to_player.y = 0.0f;

        Vector3 smooth_pos = Vector3.Lerp(tmp, to_player, smooth_factor * Time.deltaTime);
        smooth_pos.y = y_pos;

        if (smooth_pos.x <= top_left.x || smooth_pos.x >= bottom_right.x)
            smooth_pos.x = transform.position.x;

        if (smooth_pos.z <= top_left.y || smooth_pos.z >= bottom_right.y)
            smooth_pos.z = transform.position.z;

        
        transform.position = smooth_pos;
    }

    bool CheckBoundaries(Vector3 position)
    {
        Debug.Log(position);
        Debug.Log(top_left);
        Debug.Log(bottom_right);

        if (position.x <= top_left.x || position.x >= bottom_right.x || position.z >= top_left.y || position.z <= bottom_right.y)
        {
      
            return false;
        }

        
        

        return true;
    }
}
