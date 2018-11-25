using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum SHOT_TYPE
{
    LASER, 
    SHOTGUN
}

public class PlayerShoot : MonoBehaviour {

    // Use this for initialization
    public float laser_time_between_shots = 0.5f;
    public float shotgun_time_between_shots = 0.5f;
    float timer = 0.0f;

    public float laser_shoot_distance = 100;
    public float shotgun_shoot_distance = 50;
    LineRenderer shot;

    public Transform shot_position;
    public Transform shot_position_shotgun;
    SHOT_TYPE shot_type = SHOT_TYPE.LASER;
    public int laser_gun_damage = 40;
    public int shotgun_damage = 20;
    public float spread_angle_shot = 20;
    public Camera cam;

    public GameObject shot_particles;

    //audio
    public GameObject aManager;
    public AudioManager aM;
    Plane floor;

	void Start ()
    {
        shot = GetComponent<LineRenderer>();
        aM = aManager.GetComponent<AudioManager>();

        shot.enabled = false;

        floor = new Plane(Vector3.up, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Line renderer shut down
        HandleLineRenderer();

        HandleParticles();

        //Rotate
        HandleRotation();

        //Shoot
        HandleShooting();

    }

    void Shoot()
    {
        //Shoot logic
        switch (shot_type)
        {
            case SHOT_TYPE.LASER:

                if (timer >= laser_time_between_shots)
                {                 
                    shot_particles.SetActive(true);
                    
                    Ray tmp_ray = new Ray(transform.position, transform.forward);
                    RaycastHit info;

                    Physics.Raycast(tmp_ray, out info, laser_shoot_distance, 9); //9 for Enemy

                    if (info.transform)
                    {                       
                        info.transform.GetComponent<Enemy>().GetHit(laser_gun_damage);
                    }
                    aM.Play("Enemy_Laser_2");
                    LaserRenderTracer();
                    timer = 0.0f;
                }
                else
                {
                    timer += Time.deltaTime;
                }
                break;

            case SHOT_TYPE.SHOTGUN:

                if (timer >= shotgun_time_between_shots)
                {
                    shot_particles.SetActive(true);

                   // aM.Play("Enemy_Laser_2");

                    Ray[] shots = new Ray[3];
                    int index = 0;
                    for (float i = -spread_angle_shot; i <= spread_angle_shot; i += spread_angle_shot)
                    {
                        Debug.Log(i);
                        Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, i, 0.0f));
                        Vector3 shot_dir = rotation * transform.forward;
                        shots[index] = new Ray(transform.position, shot_dir);
                        index++;
                    }

                    foreach (Ray ray in shots)
                    {
                        RaycastHit info;
                        Physics.Raycast(ray, out info, shotgun_shoot_distance, 9);
                        if (info.transform)
                        {
                            info.transform.GetComponent<Enemy>().GetHit(shotgun_damage);
                            
                        }
                    }

                    ShotgunRenderTracer(shots);
                    timer = 0.0f;

                }
                else timer += Time.deltaTime;
                break;
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

    void HandleParticles()
    {
        if (!shot_particles.GetComponent<ParticleSystem>().isEmitting)
            shot_particles.SetActive(false);
    }

    void HandleShooting()
    {
        //if right Click
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (shot.enabled == true)
                shot.enabled = false;
        }
        
        if(Input.GetMouseButton(1))
        {
            shot_type = SHOT_TYPE.SHOTGUN;
        }

    }

    void LaserRenderTracer()
    {
        shot.enabled = true;
        shot.SetPosition(0,shot_position.position);
        shot.SetPosition(1,shot_position.position + (transform.forward * laser_shoot_distance));
        shot.SetPosition(2,shot_position.position);
        shot.SetPosition(3,shot_position.position + (transform.forward * laser_shoot_distance));
        shot.SetPosition(4,shot_position.position);
        shot.SetPosition(5,shot_position.position + (transform.forward * laser_shoot_distance));
    }

    void ShotgunRenderTracer(Ray[] directions)
    {
        shot.enabled = true;
        shot.SetPosition(0, shot_position_shotgun.position);
        shot.SetPosition(1, shot_position_shotgun.position + (directions[0].direction * shotgun_shoot_distance));
        shot.SetPosition(2, shot_position_shotgun.position);
        shot.SetPosition(3, shot_position_shotgun.position + (directions[1].direction * shotgun_shoot_distance));
        shot.SetPosition(4, shot_position_shotgun.position);
        shot.SetPosition(5, shot_position_shotgun.position + (directions[2].direction * shotgun_shoot_distance));        
    }

    void HandleLineRenderer()
    {
        if (shot.enabled == true)
            shot.enabled = false;
    }
}
