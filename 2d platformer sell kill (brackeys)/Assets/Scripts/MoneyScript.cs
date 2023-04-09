using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MoneyScript : MonoBehaviour
{
    public GameObject Enemy;
    public int enemyKillcount;
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        textMeshPro.text = "Money: " + enemyKillcount;
    }
}
