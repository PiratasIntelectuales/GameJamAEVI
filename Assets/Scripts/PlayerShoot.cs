﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum SHOT_TYPE
{
    LASER, 
    SHOTGUN
}

public class PlayerShoot : MonoBehaviour {

   public Animator Uianimator;

    // Use this for initialization
    public float laser_time_between_shots = 0.5f;
    public float shotgun_time_between_shots = 0.5f;
    float timer = 0.0f;

    public float laser_shoot_distance = 100;
    public float shotgun_shoot_distance = 50;
    LineRenderer shot = null;

    public Transform shot_position;
    public Transform shot_position_shotgun;
    SHOT_TYPE shot_type = SHOT_TYPE.LASER;
    public int laser_gun_damage = 40;
    public int shotgun_damage = 20;
    public float spread_angle_shot = 20;
    public Camera cam;

    public GameObject shot_particles;

    //audio
    AudioManager aM = null;
    Plane floor;

	void Start ()
    {
        Debug.Log("POLAYER START");
        if (shot == null)
        {
            shot = GetComponent<LineRenderer>();
            shot.enabled = false;
        }

        if (aM == null)
        {
            aM = FindObjectOfType<AudioManager>();
        }

        floor = new Plane(Vector3.up, Vector3.zero);
    }

    public void SetPlayer()
    {
        Debug.Log("OSTIAS YA 1");
        if (shot == null)
        {
            shot = GetComponent<LineRenderer>();
            shot.enabled = false;
        } 
    
        if(aM == null)
        {
            Debug.Log("OSTIAS YA 2");
            aM = FindObjectOfType<AudioManager>();
        }

        floor = new Plane(Vector3.up, Vector3.zero);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Uianimator.GetBool("2part"))
        {

            //Line renderer shut down
            HandleLineRenderer();

            HandleParticles();

            //Rotate
            HandleRotation();

            //Shoot
            HandleShooting();
        }
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
                    
                    Ray tmp_ray = new Ray(shot_position.position, transform.forward);
                    RaycastHit info;

                    Physics.Raycast(tmp_ray, out info, laser_shoot_distance); //9 for Enemy

                    if (info.transform)
                    {
                        
                        if(info.transform.gameObject.layer == 9)
                            info.transform.GetComponent<Enemy>().GetHit(laser_gun_damage);
                    }
                    aM.Play("Enemy_Laser_1");
                    LaserRenderTracer(info);
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

                    aM.Play("Enemy_Laser_2");

                    Ray[] shots = new Ray[3];
                    int index = 0;
                    for (float i = -spread_angle_shot; i <= spread_angle_shot; i += spread_angle_shot)
                    {
                        Debug.Log(i);
                        Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, i, 0.0f));
                        Vector3 shot_dir = rotation * transform.forward;
                        shots[index] = new Ray(shot_position_shotgun.position, shot_dir);
                        index++;
                    }

                    RaycastHit[] infos = new RaycastHit[3];
                    int infos_index = 0;
                    foreach (Ray ray in shots)
                    {
                        RaycastHit info;
                        Physics.Raycast(ray, out info, shotgun_shoot_distance);
                        if (info.transform)
                        {
                            if (info.transform.gameObject.layer == 9)
                                info.transform.GetComponent<Enemy>().GetHit(laser_gun_damage);
                        }

                        infos[infos_index] = info;
                        infos_index++;
                    }

                    ShotgunRenderTracer(shots, infos);
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
        
        if(Input.GetMouseButtonDown(1) == true)
        {
            if (shot_type == SHOT_TYPE.LASER)
                shot_type = SHOT_TYPE.SHOTGUN;
            else shot_type = SHOT_TYPE.LASER;

            FindObjectOfType<AudioManager>().Play("Cambio_Gun");
        }
        
    }

    void LaserRenderTracer(RaycastHit info)
    {
        shot.enabled = true;
        shot.SetPosition(0,shot_position.position);
        shot.SetPosition(1,shot_position.position + (transform.forward * info.distance));
        shot.SetPosition(2,shot_position.position);
        shot.SetPosition(3,shot_position.position + (transform.forward * info.distance));
        shot.SetPosition(4,shot_position.position);
        shot.SetPosition(5,shot_position.position + (transform.forward * info.distance));
    }

    void ShotgunRenderTracer(Ray[] directions, RaycastHit[] infos)
    {
        shot.enabled = true;

        if(infos[0].distance != 0)
        {
            shot.SetPosition(0, shot_position_shotgun.position);
            shot.SetPosition(1, shot_position_shotgun.position + (directions[0].direction * infos[0].distance));
        }
        else
        {
            shot.SetPosition(0, shot_position_shotgun.position);
            shot.SetPosition(1, shot_position_shotgun.position + (directions[0].direction * shotgun_shoot_distance));
        }

        if (infos[1].distance != 0)
        {
            shot.SetPosition(2, shot_position_shotgun.position);
            shot.SetPosition(3, shot_position_shotgun.position + (directions[1].direction * infos[1].distance));
        }
        else
        {
            shot.SetPosition(2, shot_position_shotgun.position);
            shot.SetPosition(3, shot_position_shotgun.position + (directions[1].direction * shotgun_shoot_distance));
        }

        if (infos[2].distance != 0)
        {
            shot.SetPosition(4, shot_position_shotgun.position);
            shot.SetPosition(5, shot_position_shotgun.position + (directions[2].direction * infos[2].distance));
        }
        else
        {
            shot.SetPosition(4, shot_position_shotgun.position);
            shot.SetPosition(5, shot_position_shotgun.position + (directions[2].direction * shotgun_shoot_distance));
        }

    }

    void HandleLineRenderer()
    {
        if (shot.enabled == true)
            shot.enabled = false;
    }
}
