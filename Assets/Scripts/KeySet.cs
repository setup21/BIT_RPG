using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySet : MonoBehaviour
{
    public GameObject KeySetting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseKeySettings()
    {
        KeySetting.SetActive(false);
    }
}
