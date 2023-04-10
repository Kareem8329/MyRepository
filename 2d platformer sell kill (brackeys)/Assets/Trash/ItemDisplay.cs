using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{

    public Item item;
    public Image image;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(item.name);

        image = GetComponent<Image>();
        // Set the sprite of the Image component to the sprite from the item
        image.sprite = item.art;

        transform.localScale = new Vector3(item.proportions.x, item.proportions.y, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
