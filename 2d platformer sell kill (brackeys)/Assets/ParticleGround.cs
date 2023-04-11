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
        //if bool groundMove activate

        groundMove = player.GetComponent<PLayerMovementScript>().groundMove;

        if (groundMove)
        {
            gameObject.SetActive(true);
        }
    }
}
