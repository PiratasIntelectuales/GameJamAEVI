using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization
    public float rotation_treeshold = 0.9f;

    public float time_between_shots = 0.5f;
    float timer = 0.0f;

    public float shoot_distance = 100;
    LineRenderer shot;
    public GameObject shot_position;

	void Start () {
        shot = GetComponent<LineRenderer>();
        shot.enabled = false;
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

            Shoot();

        }

        Debug.Log(transform.forward);
        Debug.DrawLine(transform.position, (transform.position + transform.forward));

        //Shoot
        //Ray tmp_ray = new Ray(transform.position, transform.forward);
        //RaycastHit info;

        //Physics.Raycast(tmp_ray, out info, shoot_distance);
        //info.transform;


    }

    void Shoot()
    {
        //Shoot logic
        if (timer >= time_between_shots)
        {
            StartCoroutine("RenderTracer");
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    IEnumerator RenderTracer()
    {
        shot.enabled = true;
        shot.SetPosition(0, transform.position);
        shot.SetPosition(1, transform.position + (transform.forward * 10));
        
        yield return null;
        shot.enabled = false;
    }

}
