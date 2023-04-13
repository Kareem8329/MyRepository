using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGround : MonoBehaviour
{
    public GameObject player;

    public bool groundMove;

    public float playerX;
    public float playerY;
    public float psX;
    public float psY;

    // Start is called before the first frame update
    void Start()
    {

        

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if bool groundMove activate

        groundMove = player.GetComponent<PLayerMovementScript>().groundMove;


        playerX = player.GetComponent<PLayerMovementScript>().playerXPosition;
        playerY = player.GetComponent<PLayerMovementScript>().playerYPosition;


        psX = playerX;
        psY = playerY - 0.9f;

        transform.position = new Vector3(psX, psY, transform.position.z);



        if (groundMove)
        {
            gameObject.SetActive(true);
        }

    }
}
