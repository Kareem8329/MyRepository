using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGround : MonoBehaviour
{
    
    public ParticleSystem ps;

    public ParticleSystemRenderer psRenderer;

    public GameObject player;

    public float psX;
    public float psY;

    public float playerX;
    public float playerY;

    void Start()
    {
        ps.Play();

        psRenderer = GetComponent<ParticleSystemRenderer>();

        psRenderer.enabled = false;

    }

    void Update()
    {


        playerX = player.GetComponent<PLayerMovementScript>().playerXPosition;
        playerY = player.GetComponent<PLayerMovementScript>().playerYPosition;


        psX = playerX;
        psY = playerY - 0.9f;

        transform.position = new Vector3(psX, psY, transform.position.z);


    }

}

