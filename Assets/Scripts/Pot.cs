using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public GameObject musicLvl1;
    public GameObject filmLvl1;

    public Vector3 offsetmusicLvl1;

    private bool planted = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(planted == false && other.gameObject.CompareTag("MusicSeed") == true)
        {
            GameObject temp = Instantiate(musicLvl1, transform);
            temp.transform.position = new Vector3(transform.position.x + offsetmusicLvl1.x, transform.position.y + offsetmusicLvl1.y, transform.position.z + offsetmusicLvl1.z);
            Destroy(other.gameObject);
            planted = true;
        }

        else if(planted == false && other.gameObject.CompareTag("FilmSeed") == true)
        {
            Instantiate(filmLvl1, other.gameObject.transform);
            Destroy(other.gameObject);
            planted = true;
        }
    }
}
