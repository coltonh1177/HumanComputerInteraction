/*
 * Allows for the user to hover over the button to click. Has a timer animation.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //for checking if the pointer is hovering over button
    private bool isPointerOverButton;

    //timer for how long the pointer has been over the button
    private float pointerOverButtonTimer;

    //how long to hover over button
    private float timeToHoverOver = 1.5F; //1.5 seconds (Note: need the 'F' for making 1.5 a float. Take it away if doing '1' or another integer)

    //so that we can call the CalcDisplay program
    public UnityEvent hoverOver;

    //so that we can get a timer animation (Serialize field allows us to input an image on Unity since this is a private variable)
    [SerializeField]
    private Image timerAnimation;

    //note: need to have this function when using IPointerEnterHandler
    //if the pointer is over the button, set isPointerOverButton to true
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        isPointerOverButton = true;
    }

    //note: need to have this function when using IPointerExitHandler
    //if the pointer left the button, reset everything and set isPointerOverButton to false
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        isPointerOverButton = false;
        pointerOverButtonTimer = 0;
        timerAnimation.fillAmount = 0;
    }

    //Does the checking if button is hovering, checks timer, and updates timer animation
    //note: need Update command so that it will check for changes every frame
    private void Update()
    {
        if(isPointerOverButton)
        {
            //increment the timer since we are still hovering over the button
            pointerOverButtonTimer += Time.deltaTime;
            
            //if we've hovered over the button long enough
            if(pointerOverButtonTimer >= timeToHoverOver)
            {
                //if there is a function to call, call it
                if(hoverOver != null)
                {
                    hoverOver.Invoke();
                }

                //now that the button has been hovered over long enough, reset the timer
                pointerOverButtonTimer = 0;
            }

            //update timer animation
            timerAnimation.fillAmount = pointerOverButtonTimer / timeToHoverOver;
        }
    }
}
