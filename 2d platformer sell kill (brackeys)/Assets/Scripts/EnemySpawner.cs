using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnAreaRadius;
    
    public BoxCollider2D spawnArea;
    public float spawnInterval;

    public int spawnCount;
    public int spawnCount2;

    public int spawnCountAdd = 10;

    public bool playerDead;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

        playerDead = target.GetComponent<PLayerMovementScript>().hasDied;

        spawnInterval = 10f;

        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);


        enemyPrefab.GetComponent<enemyScript>().target = GameObject.FindGameObjectWithTag("Player");


        target = enemyPrefab.GetComponent<enemyScript>().target = GameObject.FindGameObjectWithTag("Player");

        spawnCount = 0;

        spawnCount2 = 10;

    }

    // Update is called once per frame
    void Update()
    {

        playerDead = target.GetComponent<PLayerMovementScript>().hasDied;

        if (playerDead)
        {
            CancelInvoke("SpawnEnemy");
        }
        
        if (!playerDead)
        {

            if (spawnCount2 == spawnCount)
            {

                if (spawnInterval >= 4)
                {
                    spawnInterval--;
                }
                spawnCount2 = spawnCount + spawnCountAdd;

                // Cancel the existing InvokeRepeating() call
                CancelInvoke("SpawnEnemy");

                // Set up a new InvokeRepeating() call with the updated spawn interval
                InvokeRepeating("SpawnEnemy", 0f, spawnInterval);

                Debug.Log(spawnInterval.ToString());

            }


        }

        



    }

    void SpawnEnemy()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)
        );
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        newEnemy.GetComponent<enemyScript>().target = GameObject.FindGameObjectWithTag("Player");
        newEnemy.tag = "Enemy";

        spawnCount++;
    }




}
