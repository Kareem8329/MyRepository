using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGround : MonoBehaviour
{
    public GameObject player;

    public bool groundMove;

    // Start is called before the first frame update
    void Start()
    {

        

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        playerX = player.GetComponent<PlayerMovementScript>().playerXPosition;
        playerY = player.GetComponent<PlayerMovementScript>().playerYPosition;


        psX = playerX;
        psY = playerY - 0.9f;

        transform.position = new Vector3(psX, psY, transform.position.z);

        groundMove = player.GetComponent<PLayerMovementScript>().groundMove;

        if (groundMove)
        {
            gameObject.SetActive(true);
        }
    }
}
