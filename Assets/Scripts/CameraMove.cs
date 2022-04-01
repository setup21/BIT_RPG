using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMove : MonoBehaviour
{
    public float Speed = 2.0f;
    [SerializeField]
    private Transform Player = null;
    [SerializeField]
    private Tilemap tilemap;
    
    public Vector2 maxPosition;
    public Vector2 minPosition;

    public void SetResoulution()
    {
        int setWidth = 1920;
        int setHeight = 1080;

        int deviceWidth = Screen.width;
        int deviceHeight = Screen.height;

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }

    private void Start()
    {
        SetResoulution();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        SetResoulution();


        if (transform.position != Player.position)
        {
            Vector3 PlayerPosition = new Vector3(Player.position.x, Player.position.y, transform.position.z);

            PlayerPosition.x = Mathf.Clamp(Player.position.x, minPosition.x, maxPosition.x);
            PlayerPosition.y = Mathf.Clamp(Player.position.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, PlayerPosition, Speed);
        }
    }        
}
