using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    public GameObject nextLevel;
    public float timeToGrow = 5.0f;
    public float timeWatered = 3.0f;
    public Vector3 offset;

    private float timer = 0.0f;
    private float waterTimer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (waterTimer < timeWatered)
        {
            waterTimer += Time.deltaTime;
            timer += Time.deltaTime;
            if (timer >= timeToGrow)
            {
                Vector3 parentPos = transform.parent.transform.position;
                GameObject temp = Instantiate(nextLevel, transform.parent.transform);
                temp.transform.position = new Vector3(parentPos.x + offset.x, parentPos.y + offset.y, parentPos.z + offset.z);
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tear") == true)
        {
            waterTimer = 0.0f;
            Destroy(other.gameObject);
        }
    }
}
