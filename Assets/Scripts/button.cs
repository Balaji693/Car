using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool pressed;

    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        pressed = false;
    }
}
