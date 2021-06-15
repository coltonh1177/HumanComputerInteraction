using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class pointerEnter : MonoBehaviour//, IPointerEnterHandler
{
    public Text textshowed = null;
    public string value = null;
    public Vector2 deltaValue = Vector2.zero;
    public float timer = 0.0f;
    public float waitTime = 2.0f;
    public Button yourButton;

    private void OnMouseDown()
    {
        Debug.Log("clicked");
    }
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        StartCoroutine("changeWord", value);
    }
    public void onClick(PointerEventData eventData)
    {
       
       //Debug.Log(eventData.delta);
        Debug.Log("The Cursor balaaha");
        //Time.deltaTime;

        //StartCoroutine("wait");
        StartCoroutine("changeWord", value);

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine("changeWord", value);
    }
    public void changeWord(string word)
    {
        
        textshowed.text = word;
    }


    }