using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    GameObject Load_Scene;
    GameObject Start_Button;
    GameObject Game_Text;
    public MenuManager MS;

    void Start()
    {        
        Load_Scene = GameObject.Find("LoadingImage");
        Load_Scene.SetActive(false);
        
        Start_Button = GameObject.Find("StartButton");
        Game_Text = GameObject.Find("Canvas");        
    }
    public void Loading()
    {
        Load_Scene.SetActive(true);
        Load_Scene.GetComponent<Canvas>().enabled = true;
        Start_Button.SetActive(false);
        Game_Text.GetComponent<Canvas>().enabled = false;
        Invoke("GameStart", 3.5f);
    }
    public void GameStart()
    {
        Debug.Log("게임시작");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }   
}
