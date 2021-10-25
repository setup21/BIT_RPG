using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemDropping()
    {
        if (Item.appleNum > 0)
        {
            GameObject.Find("Inventory").GetComponent<InventoryManager>().InventoryRemove();
            Item.appleNum--;
            Debug.Log(Item.appleNum);
        }
    }
}
