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

	// Use this for initialization
	void Start ()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Plant");
        target = temp[Random.Range(0, temp.Length)];
        speed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
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
            transform.position = Vector3.MoveTowards(transform.position, target.GetComponent<Transform>().position, step);
        }

        if (reached && played == false)
        {
            gameObject.GetComponent<Animation>().Play();
            played = true;
        }

        if(played == true && gameObject.GetComponent<Animation>().isPlaying == false)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plant") == true)
        {
            reached = true;
        }
    }
}
