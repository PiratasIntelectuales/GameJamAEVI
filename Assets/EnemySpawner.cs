using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemyPrefabsPhase1;
    public List<GameObject> enemyPrefabsPhase2;
    public List<GameObject> enemyPrefabsPhase3;
    public List<GameObject> enemyPrefabsPhase4;
    public float timeToSpawnPhase1 = 2.0f;
    public float timeToSpawnPhase2 = 2.0f;
    public float timeToSpawnPhase3 = 2.0f;
    public float timeToSpawnPhase4 = 2.0f;
    [Space(5)]

    [Header("Times")]
    public float tPhase1 = 5;
    public float tPhase2 = 10;
    public float tPhase3 = 15;
    public float tPhase4 = 20;

    private float timerSpawn = 0.0f;
    private float timerGlobal = 0.0f;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        timerSpawn += Time.deltaTime;
        timerGlobal += Time.deltaTime;
        if(timerGlobal < tPhase1)
        {
            if(timerSpawn > timeToSpawnPhase1)
            {
                int rand = Random.Range(0, enemyPrefabsPhase1.Count);
                Instantiate(enemyPrefabsPhase1[rand]);
                timerSpawn = 0.0f;
            }
        }

        else if (timerGlobal < tPhase2)
        {
            if (timerSpawn > timeToSpawnPhase2)
            {
                int rand = Random.Range(0, enemyPrefabsPhase2.Count);
                Instantiate(enemyPrefabsPhase2[rand]);
                timerSpawn = 0.0f;
            }
        }

        else if (timerGlobal < tPhase3)
        {
            if (timerSpawn > timeToSpawnPhase3)
            {
                int rand = Random.Range(0, enemyPrefabsPhase3.Count);
                Instantiate(enemyPrefabsPhase3[rand]);
                timerSpawn = 0.0f;
            }
        }

        else if (timerGlobal < tPhase4)
        {
            if (timerSpawn > timeToSpawnPhase4)
            {
                int rand = Random.Range(0, enemyPrefabsPhase4.Count);
                Instantiate(enemyPrefabsPhase4[rand]);
                timerSpawn = 0.0f;
            }
        }
    }

    private void RestartSpawn()
    {
        timerGlobal = 0.0f;
    }
}
