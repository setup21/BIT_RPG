using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class EagleEntity : MonoBehaviour
{
    static public float speed;
    public bool Move;
    public bool MoveRight;
    float timer;
    float DelayTime;

    public Slider HPbar;
    public GameObject Enemy;    
    public Slider PHPSlider;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
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
                transform.localScale = new Vector2(-4, 4);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(4, 4);                
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
            GameObject.Find("BluePlayer").GetComponent<Animator>().SetBool("bDamage", false);
            PlayerMove.bmove = true;
        }
        if (HPbar.value <= 0.0f)
        {
            Move = false;
            /*this.GetComponent<Animator>().enabled = false;
            Destroy(Enemy, 1f);*/
            this.GetComponent<EagleDie>().enabled = true;
            this.GetComponent<CircleCollider2D>().enabled = false;            
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
            HPbar.value -= 20f;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<AudioSource>().Play();
        }

        if(trig.gameObject.CompareTag("Player"))
        {
            Move = false;
            GameObject.Find("BluePlayer").GetComponent<Animator>().SetBool("bDamage", true);            
            GameObject.Find("BluePlayer").GetComponent<AudioSource>().Play();

            Vector2 difference = transform.position - GameObject.Find("BluePlayer").transform.position;
            
            GameObject.Find("BluePlayer").transform.position = new Vector2(GameObject.Find("BluePlayer").transform.position.x - difference.x, GameObject.Find("BluePlayer").transform.position.y);

            PHPSlider.value -= 20f;
            PlayerMove.bmove = false;            
        }
    }
}
