using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private GameObject heldObj;

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
                    if (tempScript != null)
                    {
                        heldObj = tempScript.ClickedOn();
                        heldObj.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
        else
        {
            float distScreen = Camera.main.WorldToScreenPoint(heldObj.transform.position).z;
            heldObj.GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distScreen));
            if (Input.GetMouseButtonUp(0) == true)
            {
                heldObj.GetComponent<Rigidbody>().useGravity = true;
                heldObj = null;
            }
        }
	}
}
