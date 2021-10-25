using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    
    public GameObject Inventory;    
    public GameObject[] Slot = null;    
    public GameObject[] Remove = null;

    public Slider PHPSlider;

    void Update()
    {
        for (int i = 0; i < Item.appleNum; i++)
        {
            Slot[i].GetComponent<Image>().enabled = true;
            Remove[i].GetComponent<Button>().interactable = true;
        }
    }
    public void InventoryRemove()
    {
        for (int i = 0; i < 16; i++)
        {
            Slot[i].GetComponent<Image>().enabled = false;
            Remove[i].GetComponent<Button>().interactable = false;
        }        
    }
    
    public void QuestComplete()
    {
        if(PinkDialogue.bQuest == true)
        {
            for(int i = 0; i< 16; i++)
            {
                Slot[i].GetComponent<Image>().enabled = false;
                Remove[i].GetComponent<Button>().interactable = false;
            }
            for (int j = 0; j < Item.appleNum; j++)
            {
                Slot[j].GetComponent<Image>().enabled = true;
                Remove[j].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void LoadInventory()
    {
        for (int i = 0; i < 16; i++)
        {
            Slot[i].GetComponent<Image>().enabled = false;
            Remove[i].GetComponent<Button>().interactable = false;
        }
        for (int j = 0; j < Item.appleNum; j++)
        {
            Slot[j].GetComponent<Image>().enabled = true;
            Remove[j].GetComponent<Button>().interactable = true;
        }
    }

    public void HPPlus()
    {
        if(Item.appleNum>=1 && PHPSlider.value > 0)
        {
            Item.appleNum -= 1;
            PHPSlider.value += 20;
            this.GetComponent<AudioSource>().Play();

            for (int i = 0; i < 16; i++)
            {
                Slot[i].GetComponent<Image>().enabled = false;
                Remove[i].GetComponent<Button>().interactable = false;
            }
            for (int j = 0; j < Item.appleNum; j++)
            {
                Slot[j].GetComponent<Image>().enabled = true;
                Remove[j].GetComponent<Button>().interactable = true;
            }
        }
    }
}
