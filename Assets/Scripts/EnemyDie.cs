using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDie : MonoBehaviour
{
    public Slider HPbar;
    public GameObject Enemy;
    public GameObject Item;
    
    // Start is called before the first frame update
    void Start()
    {
        Item.transform.position = Enemy.transform.position;
        EnemySpawn.Count--;
        this.GetComponent<Animator>().enabled = false;
        Destroy(Enemy, 1f);
        Instantiate(Item);
        PlayerControler.Exp += 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
