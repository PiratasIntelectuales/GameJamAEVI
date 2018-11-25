using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    public GameObject nextLevel;
    public GameObject finalLevelMusic;
    public GameObject finalLevelFilm;
    public GameObject finalLevelGame;
    public float timeToGrow = 5.0f;
    public Vector3 offset;
    public int dropsNeeded = 4;
    public GameObject coolStars;

    private float timer = 0.0f;
    private int currentDrops = 0;
    private int type = 0; //0 music, 1 game, 2 film
    private int myLevel = 0;
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
                FindObjectOfType<AudioManager>().Play("Grow");
                Vector3 parentPos = transform.parent.transform.position;
                Vector3 parentScale = transform.parent.transform.localScale;
                if (myLevel != 2)
                {
                    GameObject temp = Instantiate(nextLevel, transform.parent.transform);
                    temp.GetComponent<Plant>().type = type;
                    temp.GetComponent<Plant>().myLevel = myLevel + 1;
                    temp.transform.position = new Vector3(parentPos.x + offset.x, parentPos.y + offset.y, parentPos.z + offset.z);
                    temp.transform.localScale = new Vector3(temp.transform.localScale.x / parentScale.x, temp.transform.localScale.y / parentScale.y, temp.transform.localScale.z / parentScale.z);
                    Destroy(gameObject);
                }
                else if(type == 0)
                {
                    GameObject temp = Instantiate(finalLevelMusic, transform.parent.transform);
                    temp.transform.position = new Vector3(parentPos.x + offset.x, parentPos.y + offset.y, parentPos.z + offset.z);
                    temp.transform.localScale = new Vector3(temp.transform.localScale.x / parentScale.x, temp.transform.localScale.y / parentScale.y, temp.transform.localScale.z / parentScale.z);
                    Destroy(gameObject);
                }
                else if (type == 1)
                {
                    GameObject temp = Instantiate(finalLevelGame, transform.parent.transform);
                    temp.transform.position = new Vector3(parentPos.x + offset.x, parentPos.y + offset.y, parentPos.z + offset.z);
                    temp.transform.localScale = new Vector3(temp.transform.localScale.x / parentScale.x, temp.transform.localScale.y / parentScale.y, temp.transform.localScale.z / parentScale.z);
                    Destroy(gameObject);
                }
                else if (type == 2)
                {
                    GameObject temp = Instantiate(finalLevelFilm, transform.parent.transform);
                    temp.transform.position = new Vector3(parentPos.x + offset.x, parentPos.y + offset.y, parentPos.z + offset.z);
                    temp.transform.localScale = new Vector3(temp.transform.localScale.x / parentScale.x, temp.transform.localScale.y / parentScale.y, temp.transform.localScale.z / parentScale.z);
                    Destroy(gameObject);
                }
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

    public void SetType(int value)
    {
        type = value;
    }
}
