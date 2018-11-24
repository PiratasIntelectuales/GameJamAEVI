using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    public GameObject nextLevel;
    public float timeToGrow = 5.0f;
    public Vector3 offset;

    private float timer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timeToGrow)
        {
            Vector3 parentPos = transform.parent.transform.position;
            GameObject temp = Instantiate(nextLevel, transform.parent.transform);
            temp.transform.position = new Vector3(parentPos.x + offset.x, parentPos.y + offset.y, parentPos.z + offset.z);
            Destroy(gameObject);
        }
	}
}
