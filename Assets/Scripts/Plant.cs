using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    public GameObject nextLevel;
    public float timeToGrow = 5.0f;
    public Vector3 offset;
    public int dropsNeeded = 4;
    public GameObject coolStars;

    private float timer = 0.0f;
    private int currentDrops = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentDrops >= dropsNeeded)
        {
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
            currentDrops++;
            if(currentDrops == dropsNeeded)
            {
                Vector3 potPos = transform.parent.transform.position;
                GameObject stars = Instantiate(coolStars);
                stars.transform.position = new Vector3(potPos.x - 2.9f, potPos.y + 3f, potPos.z);
            }
            Destroy(other.gameObject);
        }
    }
}
