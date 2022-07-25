using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Action TouchStart;
    public static Action TouchEnd;

    [SerializeField] private float delay;

    private float touchTime;
    private bool wasTouch;
    private bool wasLongTouch;

    private void Start()
    {
        wasLongTouch = false;
        wasTouch = false;
        touchTime = 0;
    }

    private void Update()
    {
        if (wasTouch == false) return;

        touchTime += Time.deltaTime;
        if (touchTime > delay)
        {
            TouchStart.Invoke();
            wasLongTouch = true;
            touchTime = 0;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

        wasTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        if (wasLongTouch)
        {
            TouchEnd.Invoke();
        }
        
        wasTouch = false;
        wasLongTouch = false;
    }
}
