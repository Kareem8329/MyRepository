using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject

{

    public new string name;
    public string description;

    public Vector2 proportions;

    public Sprite art;

    public int healthAdd;
    public int strengthAdd;
    public int speedAdd;
    public int jumpAdd;


    public void Print ()
    {

        Debug.Log(name + ":" + description);

    }


   
}