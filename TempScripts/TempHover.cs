/*
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TempHover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUP");
    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }

                Reset();
            }

            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }

    /*private bool IsMouseOverButton()
    {
       return EventSystem.current.IsPointerOverGameObject();
    }

    public void OnMouseOver()
    {
        //yield return new WaitForSeconds(3);
        //StartCoroutine(Test());
        if(!IsMouseOverButton())
        textDisplay.text = "507";
    }

    public void OnMouseExit()
    {
        textDisplay.text = "";
    } */

    /* IEnumerator Test()
     {
         yield return new WaitForSeconds(3);
         Debug.Log("Wait is over");
     } */
}
