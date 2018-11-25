using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("TearFloor") == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<AudioManager>().Play("Gota_Maceta");
    }
}
