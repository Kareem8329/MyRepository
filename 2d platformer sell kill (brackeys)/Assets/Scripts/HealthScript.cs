using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public GameObject player;
    
    public int playerHealth;

    private TextMeshProUGUI textMeshPro;


    // Start is called before the first frame update
    void Start()
    {

        playerHealth = player.GetComponent<PLayerMovementScript>().playerHealth;

        textMeshPro = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PLayerMovementScript>().playerHealth;
        textMeshPro.text = "Health: " + playerHealth;
    }
}
