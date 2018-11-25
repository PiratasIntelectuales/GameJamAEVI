using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {
    public int maxQuantity = 10;
    public float depletionRate = 0.1f;
    public float depletionDecrease = 0.05f;
    public GameObject tear;

    private float quantity = 0.0f;
    private float timer = 0.0f;
    private float deplete = 0.0f;
    private GameObject colliding;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(quantity>0)
        {
            timer += Time.deltaTime;
            if(timer>deplete)
            {
                timer = 0.0f;
                GameObject tempTear = Instantiate(tear);
                tempTear.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y - 0.3f, transform.position.z);
                tempTear.GetComponent<Rigidbody>().AddForce(new Vector3(0, -0.0001f, 0));
                deplete += depletionDecrease;
                quantity--;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Well"))
        {
            FindObjectOfType<AudioManager>().Play("Cubo_Agua");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Well"))
        {
            quantity = maxQuantity;
            deplete = depletionRate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Well") == false && colliding != collision.gameObject)
        {
            colliding = collision.gameObject;
            FindObjectOfType<AudioManager>().Play("Cubo_Agua_Suelo");
        }
    }


}
