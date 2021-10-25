using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject apple;
    static public int appleNum;
    
    // Start is called before the first frame update
    void Start()
    {
        apple.GetComponent<CircleCollider2D>().enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            apple.GetComponent<CircleCollider2D>().enabled = true;          
        }

        Invoke("OverApple", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (appleNum < 16)
            {
                appleNum++;
                Destroy(apple);
                Debug.Log(appleNum);
            }
        }
    }

    private void OverApple()
    {
        Destroy(apple);
    }

}
