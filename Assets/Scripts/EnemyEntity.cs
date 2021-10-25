using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class EnemyEntity : MonoBehaviour
{
    public float speed;
    public bool Move;
    public bool MoveRight;
    float timer;
    float DelayTime;

    public Slider HPbar;
    public GameObject Enemy;    

    // Start is called before the first frame update
    void Start()
    {   
        Move = true;
        timer = 0.0f;
        DelayTime = 1.0f;
        //HPbar = HPbar.GetComponent<Slider>();
        HPbar.value = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            if (MoveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-2, 2);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(2, 2);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (timer >= DelayTime)
        {
            Move = true;
            this.GetComponent<Animator>().enabled = true;
            timer = 0.0f;
        }
        if (HPbar.value <= 0.0f)
        {
            Move = false;
            /*this.GetComponent<Animator>().enabled = false;
            Destroy(Enemy, 1f);*/
            this.GetComponent<EnemyDie>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (MoveRight == false)
            {
                MoveRight = true;
            }
            else
            {
                MoveRight = false;
            }
        }
        /*if(trig.gameObject.CompareTag("Player"))
        {
            transform.Translate(0 * Time.deltaTime * speed, 0, 0);
        }*/
        if (trig.gameObject.CompareTag("Attack"))
        {
            Move = false;
            HPbar.value -= 35f;
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Animator>().enabled = false;       
        }
    }    
}
