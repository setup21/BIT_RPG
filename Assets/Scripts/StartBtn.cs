using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    [SerializeField] private GameObject Load_Scene;
    [SerializeField] private GameObject Start_Button;
    [SerializeField] private GameObject Game_Text;
    [SerializeField] private GameObject Title_UI;

    public void Loading()
    {
        Load_Scene.SetActive(true);
        Start_Button.SetActive(false);
        Title_UI.SetActive(false);
        Invoke("GameStart", 3.5f);
    }
    public void GameStart()
    {
        Debug.Log("게임시작");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }   
}
