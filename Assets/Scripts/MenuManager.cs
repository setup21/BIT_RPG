using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject KeySet;
    public GameObject Player;
    private bool Open;
    public Slider PHPSlider;
    public Slider PEXPSlider;
    public GameObject Inven;
    public GameObject LevelText;
    

    // Start is called before the first frame update

    void Start()
    {
        Open = false;
        Menu.SetActive(false);
        KeySet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MenuKey();
    }

    private void MenuKey()
    {
        if (Open == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(true);
                Open = true;
                PlayerMove.bmove = false;
            }
        }
        else if (Open == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(false);
                Open = false;
                PlayerMove.bmove = true;
            }
        }
    }
    public void OpenKeySettings()
    {
        KeySet.SetActive(true);
        Menu.SetActive(false);
        PlayerMove.bmove = true;
        Open = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.SetInt("AppleNum", Item.appleNum);
        if (PinkDialogue.bQuest == true)
        {
            PlayerPrefs.SetFloat("PinkQuest", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("PinkQuest", 0);
        }
        PlayerPrefs.SetInt("MaskQuest", MaskDialogue.IQuest);
        if (FrogDialogue.bQuest == true)
        {
            PlayerPrefs.SetFloat("FrogQuest", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("FrogQuest", 0);
        }
        PlayerPrefs.SetInt("EagleDie", EagleDie.Eaglekill);
        PlayerPrefs.SetFloat("PHP", PHPSlider.value);
        PlayerPrefs.SetFloat("PEXP", PEXPSlider.value);
        PlayerPrefs.SetInt("PLV", PlayerControler.PlayerLevel);
        PlayerPrefs.SetInt("Eagledie", EagleDie.Eaglekill);
        PlayerPrefs.SetFloat("EXP", PlayerControler.Exp);
        

        PlayerPrefs.Save();
        Menu.SetActive(false);
        PlayerMove.bmove = true;        
    }
    public void GameLoad()

    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        Item.appleNum = PlayerPrefs.GetInt("AppleNum");
        MaskDialogue.IQuest = PlayerPrefs.GetInt("MaskQuest");
        EagleDie.Eaglekill = PlayerPrefs.GetInt("EagleDie");
        PlayerControler.PlayerLevel = PlayerPrefs.GetInt("PLV");
        PHPSlider.value = PlayerPrefs.GetFloat("PHP");
        PEXPSlider.value = PlayerPrefs.GetFloat("PEXP");
        EagleDie.Eaglekill = PlayerPrefs.GetInt("Eagledie");
        PlayerControler.Exp = PlayerPrefs.GetFloat("EXP");

        if (PlayerPrefs.GetFloat("PinkQuest") == 1)
        {
            PinkDialogue.bQuest = true;
        }
        else
        {
            PinkDialogue.bQuest = false;
        }
        if (PlayerPrefs.GetFloat("FrogQuest") == 1)
        {
            FrogDialogue.bQuest = true;
        }
        else
        {
            FrogDialogue.bQuest = false;
        }

        Player.transform.position = new Vector3(x, y, 0);
        Inven.GetComponent<InventoryManager>().LoadInventory();
        PlayerControler.Exp = PEXPSlider.value;
        LevelText.GetComponent<Text>().text = "" + PlayerControler.PlayerLevel;
        Menu.SetActive(false);
        PlayerMove.bmove = true;
    }

}
