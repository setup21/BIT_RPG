using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    PlayerMove Stop;
    [SerializeField] private GameObject AttPoint = null;
    float waitingTime;
    float RespawnTime;
    float timer;    
    public GameObject Inventory;
    bool Open;
    public Slider PHPSlider;
    public Slider PEXPSlider;
    public static int PlayerLevel = 1;
    static public float Exp = 0f;
    public LevelScript LS; //LevelScript
    [SerializeField] private GameObject RespawnPoint = null;
    [SerializeField] private GameObject DeathSound = null;

    // Start is called before the first frame update
    void Start()
    {
        Stop = GameObject.Find("BluePlayer").GetComponent<PlayerMove>();
        //AttPoint = GameObject.Find("AttackPoint");
        waitingTime = 0.6f;
        timer = 0.0f;
        Inventory.SetActive(false);
        Open = false;
        PHPSlider.value = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > waitingTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) && PlayerMove.bmove == true)
            {
                AttPoint.SetActive(true);
                AttPoint.transform.localPosition = new Vector2(0.25f, -0.05f);
                Stop.enabled = false;
                //Attack();
                timer = 0;                
                
            }
            else
            {
                AttPoint.SetActive(false);
                Stop.enabled = true;
            }
        }
        InventoryKey();

        if(Exp >= 100)
        {            
            Exp -= 100;
            PlayerLevel += 1;
            LS.ReNew();
        }        
        
        PEXPSlider.value = Exp;

        if(PHPSlider.value <= 0)
        {
            Invoke("DSound", 1f);
            PlayerMove.bmove = false;
            GetComponent<Animator>().SetBool("bDie", true);
            GetComponent<CircleCollider2D>().enabled = false;

            if(Input.GetKey(KeyCode.R) && PHPSlider.value <= 0)
            {
                Invoke("RSound", 5f);
                Invoke("Respawn", 2.0f);
            
            }
        }
    }
    private void Attack()
    {
        AttPoint.SetActive(true);
    }

    private void InventoryKey()
    {
        if (Open == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Inventory.SetActive(true);
                Open = true;
            }
        }
        else if (Open == true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Inventory.SetActive(false);
                Open = false;
            }
        }        
    }    
    private void Respawn()
    {
        PHPSlider.value = 40.0f;
        this.transform.position = RespawnPoint.transform.position;
        Invoke("RMove", 2.1f);
        GetComponent<Animator>().SetBool("bDie", false);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    private void DSound()
    {
        DeathSound.SetActive(true);
    }
    private void RSound()
    {
        DeathSound.SetActive(false);
    }
    private void RMove()
    {
        PlayerMove.bmove = true;
    }
}
