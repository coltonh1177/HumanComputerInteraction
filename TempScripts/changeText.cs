using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeText : MonoBehaviour
{
    public Text textshowed = null;
    int value1 = -1;
    int value2 = -1;
    string second = "";
    bool hitOp = false;
    bool hitequal = false;
    public void changeWord(string word)
    {
        string operater = "";
        
        if (word.Equals("x"))
        {
            operater = word;
            value1 = int.Parse(textshowed.text);
            textshowed.text = textshowed.text + word;
            hitOp = true;
            hitequal = false;
        }
        else if (word.Equals("=")){
            value2 = int.Parse(second);
            int final = value1 * value2;
            Debug.Log(value1);
            Debug.Log(value2);
            textshowed.text = final.ToString();
            hitequal = true;
            second = "";
            operater = "";
            hitOp = false;
        }
        else
        {
            if(hitequal)
            {
                textshowed.text = "";
                second = "";
                hitequal = false;
            }
            if (hitOp)
            {
                second = second + word;
            }
            
             textshowed.text = textshowed.text + word;
            
        }
    }
}
