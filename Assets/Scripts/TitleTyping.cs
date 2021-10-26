using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;

public class TitleTyping : MonoBehaviour
{
    [SerializeField] GameObject Start_Button;
    [SerializeField] GameObject Load_Image;
    [SerializeField] GameObject Text;
    public float typingSpeed;
    public string sentence;

    private void Start()
    {
        Start_Button.SetActive(false);
        Load_Image.SetActive(false);

        Text.GetComponent<TextMeshProUGUI>().text = ""; 
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach (char ch in sentence.ToCharArray())
        {
            Text.GetComponent<TextMeshProUGUI>().text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }        
    }    
            void Update()
    {
        if (Text.GetComponent<TextMeshProUGUI>().text == "Bit RPG")
            Start_Button.SetActive(true);
    }
}
