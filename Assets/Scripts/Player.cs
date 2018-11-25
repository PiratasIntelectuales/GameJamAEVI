using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private GameObject heldObj;
    private bool heldBucket = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (heldObj == null)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    SeedBags tempScript = hit.collider.gameObject.GetComponent<SeedBags>();
                    Bucket tempBucket = hit.collider.gameObject.GetComponent<Bucket>();
                    if (tempScript != null)
                    {
                        heldObj = tempScript.ClickedOn();
                        heldObj.GetComponent<Rigidbody>().useGravity = false;
                    }
                    else if(tempBucket != null)
                    {
                        heldObj = hit.collider.gameObject;
                        heldObj.GetComponent<Rigidbody>().useGravity = false;
                        heldBucket = true;
                    }
                }
            }
        }
        else
        {
            float distScreen = Camera.main.WorldToScreenPoint(heldObj.transform.position).z;
            heldObj.GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distScreen));
            if(heldBucket == true)
            {
                Vector3 pos = heldObj.GetComponent<Transform>().position;
                heldObj.GetComponent<Transform>().position = new Vector3(pos.x, pos.y - 11.4f, pos.z);
            }
            if (Input.GetMouseButtonDown(0) == true)
            {
                heldObj.GetComponent<Rigidbody>().useGravity = true;
                if(heldBucket == true)
                {
                }
                heldObj = null;
                heldBucket = false;
            }
        }
	}
}
