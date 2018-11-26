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

    public int life = 1;
    public float timeToDie = 3.0f;

    bool particle_spawn_activated = true;
    float particle_timer = 0.0f;
    public GameObject prefab_spawn_particle_system;
    GameObject spawn_particle_system;
    GameObject die_particle_system;
    public SkinnedMeshRenderer skinner;
    public GameObject die_particles;
    private float dieTimer = 0.0f;
    private bool dying = false;

    // Use this for initialization
    void Start ()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Plant");
        GameObject[] tempMovies = GameObject.FindGameObjectsWithTag("MaxMovies");
        GameObject[] tempMusic = GameObject.FindGameObjectsWithTag("MaxMusic");
        GameObject[] tempGames = GameObject.FindGameObjectsWithTag("MaxGames");
        List<GameObject> tempList = new List<GameObject>();
        foreach (GameObject plant in temp)
        {
            tempList.Add(plant);
        }
        foreach (GameObject plant in tempMovies)
        {
            tempList.Add(plant);
        }
        foreach (GameObject plant in tempMusic)
        {
            tempList.Add(plant);
        }
        foreach (GameObject plant in tempGames)
        {
            tempList.Add(plant);
        }
        target = tempList[Random.Range(0, tempList.Count)];
        speed = maxSpeed;

     
    }

    private void OnEnable()
    {
        spawn_particle_system = Instantiate(prefab_spawn_particle_system, transform);
        spawn_particle_system.SetActive(true);
        skinner.enabled = false;
        GetComponent<BoxCollider>().enabled = false;

    }

// Update is called once per frame
void Update ()
    {
        if(target == null && reached == false)
        {
            Retarget();
        }
        //particle spawn
        if(spawn_particle_system != null)
        {
            if (particle_timer >= 3.0)
            {
                Destroy(spawn_particle_system);
                skinner.enabled = true;
                FindObjectOfType<AudioManager>().PlayRandAudio2("Mio_4", "Mio_1", "Mio_2", "Mio_3");
                GetComponent<BoxCollider>().enabled = true;
            }
            else particle_timer += Time.deltaTime;

            return;
        }

        if(dying)
        {
            dieTimer += Time.deltaTime;
            if(dieTimer>=timeToDie)
            {
                Die();
            }
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
            dying = true;
            die_particle_system = Instantiate(die_particles, transform);
            die_particle_system.SetActive(true);
            GetComponent<Animator>().SetBool("Dying", true);
            GetComponent<BoxCollider>().enabled = false;
            skinner.enabled = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plant") == true || other.gameObject.CompareTag("MaxMovies") == true || other.gameObject.CompareTag("MaxMusic") == true || other.gameObject.CompareTag("MaxGames") == true)
        {
            reached = true;
            Destroy(other.gameObject);
        }
    }

    public void GetHit(int damage)
    {
        life -= damage;

        FindObjectOfType<AudioManager>().Play("Enemy_Hit_1");

        if (life <= 0 && dying == false)
        {
            dying = true;
            die_particle_system = Instantiate(die_particles, transform);
            die_particle_system.SetActive(true);
            GetComponent<Animator>().SetBool("Dying", true);
            FindObjectOfType<AudioManager>().Play("Enemy_dead_1");
            GetComponent<BoxCollider>().enabled = false;
            skinner.enabled = false;
        }
    }

    void Die()
    {
        FindObjectOfType<PlayerManager>().AddCash(5);
      
        Destroy(gameObject);
    }

    void Retarget()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Plant");
        GameObject[] tempMovies = GameObject.FindGameObjectsWithTag("MaxMovies");
        GameObject[] tempMusic = GameObject.FindGameObjectsWithTag("MaxMusic");
        GameObject[] tempGames = GameObject.FindGameObjectsWithTag("MaxGames");
        List<GameObject> tempList = new List<GameObject>();
        foreach (GameObject plant in temp)
        {
            tempList.Add(plant);
        }
        foreach (GameObject plant in tempMovies)
        {
            tempList.Add(plant);
        }
        foreach (GameObject plant in tempMusic)
        {
            tempList.Add(plant);
        }
        foreach (GameObject plant in tempGames)
        {
            tempList.Add(plant);
        }
        target = tempList[Random.Range(0, tempList.Count)];
        speed = maxSpeed;
    }

}
