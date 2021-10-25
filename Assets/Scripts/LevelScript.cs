using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public GameObject LevelText;

    public void ReNew()
    {
        LevelText.GetComponent<Text>().text = "" + PlayerControler.PlayerLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelText.GetComponent<Text>().text += PlayerControler.PlayerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
