using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EagleDie : MonoBehaviour
{
    public Slider HPbar;
    public GameObject Enemy;
    static public int Eaglekill = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn.Count--;
        this.GetComponent<Animator>().enabled = false;
        Destroy(Enemy, 1f);
        Eaglekill++;
        EagleEntity.speed += 0.5f;
        PlayerControler.Exp += 35;
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
