using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float Speed = 2.0f;
    [SerializeField]
    private Transform Player = null;
    
    public Vector2 maxPosition;
    public Vector2 minPosition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != Player.position)
        {
            Vector3 PlayerPosition = new Vector3(Player.position.x, Player.position.y, transform.position.z);

            PlayerPosition.x = Mathf.Clamp(Player.position.x, minPosition.x, maxPosition.x);
            PlayerPosition.y = Mathf.Clamp(Player.position.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, PlayerPosition, Speed);
        }
    }        
}
