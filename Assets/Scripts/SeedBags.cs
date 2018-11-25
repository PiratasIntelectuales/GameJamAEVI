﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBags : MonoBehaviour {
    public GameObject seed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject ClickedOn()
    {
        if (CompareTag("MusicBag") == true)
        {
            return Instantiate(seed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, -90, 0));
        }
        else
        {
            return Instantiate(seed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
        }
    }
}
