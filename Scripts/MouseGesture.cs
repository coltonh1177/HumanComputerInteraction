using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseGesture : MonoBehaviour
{
    //so that we can call the CalcDisplay program
    public UnityEvent callReset;

    // Update is called once per frame
    void Update()
    {
        //getting x and y delta movements
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //if we've moved rapidly enough
        //call the function
        if(x > 2.5 || y > 2.5)
        {
            if(callReset != null)
            {
                callReset.Invoke();
            }
        }
        
    }
}
