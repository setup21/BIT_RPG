using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickMove :  MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image JoyStickBackground;
    [SerializeField] private Image JoyStickPed;
    private Vector3 inputVector;

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoyStickBackground.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / JoyStickBackground.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JoyStickBackground.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            JoyStickPed.rectTransform.anchoredPosition = new Vector3(inputVector.x * (JoyStickBackground.rectTransform.sizeDelta.x / 3), inputVector.y * (JoyStickBackground.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        JoyStickPed.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float GetHorizontalValue()
    {
        return inputVector.x;
    }

    public float GetVerticalValue()
    {
        return inputVector.y;
    }
}
