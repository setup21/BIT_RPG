using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;

public class TitleTyping : MonoBehaviour
{
    GameObject Start_Button;
    GameObject Load_Image;
    GameObject Text;
    public float typingSpeed;
    public string sentence;
    /*public enum AnimationMode { VertexColor, Jitter};
    public AnimationMode MeshAnimationMode = AnimationMode.Jitter;
    private TextMeshPro m_TextMeshPro;
    private TextContainer m_TextContainer;

    private TextInfo m_textInfo;*/

    /*private void Awake()
    {
        m_TextMeshPro = gameObject.AddComponent<TextMeshPro>();
        m_TextMeshPro.text = Text.GetComponent<TextMeshPro>().text;
        m_TextMeshPro.enableWordWrapping = true;
        m_TextContainer = GetComponent<TextContainer>();
        m_TextContainer.width = 10f;

        m_TextMeshPro.ForceMeshUpdate();
    }*/

    private void Start()
    {        
        Load_Image = GameObject.Find("LoadingImage");
        Load_Image.GetComponent<Canvas>().enabled = false;
        Start_Button = GameObject.Find("StartButton");
        Start_Button.SetActive(false);
        Text = GameObject.Find("Title");

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
