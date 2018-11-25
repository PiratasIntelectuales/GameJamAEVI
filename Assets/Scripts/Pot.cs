using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public GameObject musicLvl1;

    public Vector3 offsetmusicLvl1;

    public bool planted = false;
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
            temp.GetComponent<Plant>().SetType(0);
            temp.transform.position = new Vector3(transform.position.x + offsetmusicLvl1.x, transform.position.y + offsetmusicLvl1.y, transform.position.z + offsetmusicLvl1.z);
            temp.transform.localScale = new Vector3(temp.transform.localScale.x / transform.localScale.x, temp.transform.localScale.y / transform.localScale.y, temp.transform.localScale.z / transform.localScale.z);
            Destroy(other.gameObject);
            planted = true;
        }

        else if (planted == false && other.gameObject.CompareTag("GameSeed") == true)
        {
            GameObject temp = Instantiate(musicLvl1, transform);
            temp.GetComponent<Plant>().SetType(1);
            temp.transform.position = new Vector3(transform.position.x + offsetmusicLvl1.x, transform.position.y + offsetmusicLvl1.y, transform.position.z + offsetmusicLvl1.z);
            temp.transform.localScale = new Vector3(temp.transform.localScale.x / transform.localScale.x, temp.transform.localScale.y / transform.localScale.y, temp.transform.localScale.z / transform.localScale.z);
            Destroy(other.gameObject);
            planted = true;
        }

        else if(planted == false && other.gameObject.CompareTag("FilmSeed") == true)
        {
            GameObject temp = Instantiate(musicLvl1, transform);
            temp.GetComponent<Plant>().SetType(2);
            temp.transform.position = new Vector3(transform.position.x + offsetmusicLvl1.x, transform.position.y + offsetmusicLvl1.y, transform.position.z + offsetmusicLvl1.z);
            temp.transform.localScale = new Vector3(temp.transform.localScale.x / transform.localScale.x, temp.transform.localScale.y / transform.localScale.y, temp.transform.localScale.z / transform.localScale.z);
            Destroy(other.gameObject);
            planted = true;
        }
    }
}
