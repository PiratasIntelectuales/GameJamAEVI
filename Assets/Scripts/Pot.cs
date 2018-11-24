using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {

    private bool planted = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(planted == false && (other.gameObject.CompareTag("MusicSeed") == true || other.gameObject.CompareTag("FilmSeed") == true))
        {
            gameObject.GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
            Destroy(other.gameObject);
            planted = true;
        }
    }
}
