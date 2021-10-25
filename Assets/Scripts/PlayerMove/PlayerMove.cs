using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private JoyStickMove joystickmove;
    private SpriteRenderer spriterenderer; // spriterenderer.flip 으로 좌우 방향 전환 가능.
    public float speed = 3;
    static public bool bmove;

    private Vector2 direction;

    private void Awake()
    {
        spriterenderer = this.GetComponent<SpriteRenderer>();

        joystickmove = GameObject.FindGameObjectWithTag("PlayerUI").GetComponentInChildren<JoyStickMove>();
    }
    void Start()
    {
        bmove = true;
    }

    void FixedUpdate()
    {
        if (bmove == true)
        {
            Move();
        }
    }

    private void Move()
    {       
        direction = Vector2.zero;
        GetComponent<Animator>().SetBool("bMove", false);

        if (Input.GetKey(KeyCode.UpArrow) || joystickmove.GetVerticalValue() > 0.2f)
        {
            direction += Vector2.up;
            GetComponent<Animator>().SetBool("bMove", true);
        }
        if (Input.GetKey(KeyCode.DownArrow) || joystickmove.GetVerticalValue() < -0.2f)
        {
            direction += Vector2.down;
            GetComponent<Animator>().SetBool("bMove", true);
        }
        if (Input.GetKey(KeyCode.RightArrow) || joystickmove.GetHorizontalValue() > 0.2f)
        {
            direction += Vector2.right;
            spriterenderer.flipX = false;
            GetComponent<Animator>().SetBool("bMove", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || joystickmove.GetHorizontalValue() < -0.2f)
        {
            direction += Vector2.left;
            GetComponent<Animator>().SetBool("bMove", true);
            spriterenderer.flipX = true;
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
