using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    

    public GameObject player;
    public GameObject newEnemy;
    public int rndX = new System.Random().Next(-19, 24);



    // Start is called before the first frame update
    void Start()
    {

        

    }
    


    // Update is called once per frame
    void Update()
    {
        rndX = new System.Random().Next(-19, 24);

        newEnemy = GameObject.FindGameObjectWithTag("Enemy");

        transform.position = new Vector3(player.transform.position.x, -13.8f, 0) ;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(rndX, 5, 0);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            newEnemy.transform.position = new Vector3(rndX, 5, 0);
        }

    }
}
