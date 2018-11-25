using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float maxSpeed = 1f;
    public float minSpeed = 0.5f;
    public float deceleration = 0.1f;

    private float speed = 0.0f;
    private GameObject target;
    private bool reached = false;
    private bool played = false;

    public int life = 100;

    bool particle_spawn_activated = true;
    float particle_timer = 0.0f;
    public GameObject prefab_spawn_particle_system;
    GameObject spawn_particle_system;

    // Use this for initialization
    void Start ()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Plant");
        target = temp[Random.Range(0, temp.Length)];
        speed = maxSpeed;

        
    }

    private void OnEnable()
    {
        spawn_particle_system = Instantiate(prefab_spawn_particle_system, transform);
        spawn_particle_system.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<MeshRenderer>();
        foreach(MeshRenderer comp in GetComponentsInChildren<MeshRenderer>())
        {
            comp.enabled = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //particle spawn
        if(spawn_particle_system != null)
        {
            if (particle_timer >= 3.0)
            {
                Destroy(spawn_particle_system);
                GetComponent<MeshRenderer>().enabled = true;
            }
            else particle_timer += Time.deltaTime;

            return;
        }

        //Spawn enemy
		if(!reached)
        {
            if (speed > minSpeed)
            {
                speed = speed - deceleration * Time.deltaTime;
                if(speed < minSpeed)
                {
                    speed = minSpeed;
                }
            }
            float step = speed * Time.deltaTime;
            Vector3 targetPos = target.GetComponent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            transform.rotation = Quaternion.LookRotation(targetPos - transform.position, Vector3.up);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90.0f);
        }

        if (reached && played == false)
        {
            played = true;
        }

        if(played == true)
        {
            Die();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plant") == true)
        {
            reached = true;
        }
    }

    public void GetHit(int damage)
    {
        life -= damage;

        if (life <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
