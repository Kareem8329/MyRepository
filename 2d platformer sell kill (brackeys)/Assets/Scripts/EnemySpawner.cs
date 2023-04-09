using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnAreaRadius;
    public float spawnInterval = 10f;
    public BoxCollider2D spawnArea;



    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);

        enemyPrefab.GetComponent<enemyScript>().target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        


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

    }




}
