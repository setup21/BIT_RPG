using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MaskDialogue : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Image;
    public GameObject Text;
    public GameObject Next;
    public GameObject Name;

    int index;
    public string[] sentences1; //퀘스트
    public string[] sentences2; //미완료시
    public string[] sentences3; // 완료시
    public string[] sentences4;
    public float typingSpeed;

    bool bStart;
    bool bEnd;
    public bool bQuest; //미션 완료 신호
    static public int IQuest; // 미션 완료 개수 체크
    bool MissionAsk;



    void Start()
    {
        bStart = false;
        bEnd = false;
        bQuest = false;
        IQuest = 0;
        MissionAsk = false;
        /*Canvas = GameObject.Find("DialogueCanvas");
        Image = GameObject.Find("DialogueImage");        
        Text = GameObject.Find("DialogueText");
        Next = GameObject.Find("DialogueNext");*/

        Canvas.GetComponent<Canvas>().enabled = true;
        Image.SetActive(false);
        Text.SetActive(false);
        Next.SetActive(false);
        Name.SetActive(false);
    }

    public bool IsEnd()
    {
        return bEnd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }
        if (bStart == false && bQuest == false && MissionAsk == false)
        {
            bStart = true;
            Name.SetActive(true);
            Name.GetComponent<Text>().text = "촌장님";
            index = 0;
            Image.SetActive(true);
            Text.SetActive(true);
            Text.GetComponent<Text>().text = "";

            StartCoroutine(Type1());
        }

        if (bStart == false && bQuest == false && IQuest>=0 && IQuest <2 && MissionAsk == true)
        {
            bStart = true;
            Name.SetActive(true);
            Name.GetComponent<Text>().text = "촌장님";
            index = 0;
            Image.SetActive(true);
            Text.SetActive(true);
            Text.GetComponent<Text>().text = "";

            StartCoroutine(Type2());
        }

        if (bStart == false && bQuest == false && IQuest >=2 && MissionAsk == true)
        {
            bStart = true;
            Name.SetActive(true);
            Name.GetComponent<Text>().text = "촌장님";
            index = 0;
            Image.SetActive(true);
            Text.SetActive(true);
            Text.GetComponent<Text>().text = "";

            StartCoroutine(Type3());
        }

        if (bStart == false && bQuest == true)
        {
            bStart = true;
            Name.SetActive(true);
            Name.GetComponent<Text>().text = "촌장님";
            index = 0;
            Image.SetActive(true);
            Text.SetActive(true);
            Text.GetComponent<Text>().text = "";

            StartCoroutine(Type4());
        }
    }

    IEnumerator Type1()
    {
        foreach (char ch in sentences1[index].ToCharArray())
        {
            Text.GetComponent<Text>().text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Type2()
    {
        foreach (char ch in sentences2[index].ToCharArray())
        {
            Text.GetComponent<Text>().text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Type3()
    {
        foreach (char ch in sentences3[index].ToCharArray())
        {
            Text.GetComponent<Text>().text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    IEnumerator Type4()
    {
        foreach (char ch in sentences4[index].ToCharArray())
        {
            Text.GetComponent<Text>().text += ch;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    public void NextSentence()
    {
        Next.SetActive(false);

        if (index < sentences1.Length - 1 && bQuest == false && MissionAsk == false)
        {
            index++;
            Text.GetComponent<Text>().text = "";
            StartCoroutine(Type1());
        }

        else if (index < sentences2.Length - 1 && bQuest == false && IQuest >= 0 && IQuest < 2 && MissionAsk == true)
        {
            index++;
            Text.GetComponent<Text>().text = "";
            StartCoroutine(Type2());
        }

        else if (index < sentences3.Length - 1 && bQuest == false && IQuest >= 2 && MissionAsk == true)
        {
            index++;
            Text.GetComponent<Text>().text = "";
            StartCoroutine(Type3());
        }
        else if (index < sentences4.Length - 1 && bQuest == true && MissionAsk == true)
        {
            index++;
            Text.GetComponent<Text>().text = "";
            StartCoroutine(Type4());
        }
        else
        {
            Text.GetComponent<Text>().text = "";
            Next.SetActive(false);
            Image.SetActive(false);
            Text.SetActive(false);            
            bEnd = false;
            bStart = false;
            Name.SetActive(false);            
            PlayerMove.bmove = true;
            MissionAsk = true;


            if (IQuest>=2 && bQuest == false)
            {
                bQuest = true;
                QuestCom();
            }
        }
    }

    void Update()
    {
        if (!bStart || bEnd)
        {            
            return;
        }

        if(bStart == true)
        {
            PlayerMove.bmove = false;
            GameObject.Find("BluePlayer").GetComponent<Animator>().SetBool("bMove", false);
        }

        if (Text.GetComponent<Text>().text == sentences1[index] || Text.GetComponent<Text>().text == sentences2[index] || Text.GetComponent<Text>().text == sentences3[index] || Text.GetComponent<Text>().text == sentences4[index])
            Next.SetActive(true);
            

        if (Next.activeSelf && Input.GetButtonDown("Fire1"))
            NextSentence();
    }
    public void QuestCom()
    {
        if (bQuest == true)
        {
            //펫 활성화            
        }
    }
}
