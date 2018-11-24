using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization
    public float time_between_shots = 0.5f;
    float timer = 0.0f;

    public float shoot_distance = 100;
    LineRenderer shot;
    public GameObject shot_position;

    public int gun_damage = 40;
    public Camera cam;

    Plane floor;
	void Start () {
        shot = GetComponent<LineRenderer>();
        shot.enabled = false;

        floor = new Plane(Vector3.up, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Rotate
        HandleRotation();

        //Shoot
        HandleShooting();

        /*if (axis.magnitude > rotation_treeshold)
        {
            float angle = (Mathf.Atan2(axis.x, axis.y) * Mathf.Rad2Deg);
            Quaternion tmp = Quaternion.AngleAxis(angle , Vector3.up);
            transform.rotation = tmp;

            Shoot();

        }*/

    }

    void Shoot()
    {
        //Shoot logic
        if (timer >= time_between_shots)
        {
            //Shoot
            Ray tmp_ray = new Ray(transform.position, transform.forward);
            RaycastHit info;

            Physics.Raycast(tmp_ray, out info, shoot_distance, 9); //9 for Enemy
            
            if(info.transform)
            {
                Debug.Log("HIT");
                info.transform.GetComponent<Enemy>().GetHit(gun_damage);
            }

            StartCoroutine("RenderTracer");
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void HandleRotation()
    {
        Ray mouse_ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (floor.Raycast(mouse_ray, out distance))
        {
            Vector3 target = mouse_ray.GetPoint(distance);
            Vector3 direction = target - transform.position;

            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    void HandleShooting()
    {
        //if right Click
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    IEnumerator RenderTracer()
    {
        shot.enabled = true;
        shot.SetPosition(0, transform.position);
        shot.SetPosition(1, transform.position + (transform.forward * shoot_distance));
        
        yield return null;
        shot.enabled = false;
    }

}
