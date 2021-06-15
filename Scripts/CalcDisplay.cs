/*
 * Main Calculator Program for doing calculations and displaying them on screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcDisplay : MonoBehaviour
{
    //for displaying the text
    public Text textDisplay;
    //2 values to evaluate
    double value1 = -1;
    double value2 = -1;
    //for use in getting value2 from display and buttons
    string second = "";
    //for use with the operators and equal buttons
    bool hitOp = false;
    bool hitequal = false;
    string op = "";
    string first = "";

    //Reset everything
    public void Reset()
    {
        textDisplay.text = "";
        value1 = -1;
        value2 = -1;
        second = "";
        hitOp = false;
        hitequal = false;
        op = "";
        first = "";
    }

    //doing calculations and changing the calc display
    public void changeDisplay(string button)
    {
        //addition button hit  Note: Unity auto error handles if it is pressed before value 1 has anything)
        if (button.Equals("+"))
        {
            op = button;
            //value1 is first number in display
            value1 = double.Parse(textDisplay.text);
            //add to textDisplay
            first = textDisplay.text;
            textDisplay.text = textDisplay.text + button;
            //operator has been hit and we aren't doing evaluation yet
            hitOp = true;
            hitequal = false;
        }
        //subtraction button hit  Note: Unity auto error handles if it is pressed before value 1 has anything)
        else if (button.Equals("-"))
        {
            op = button;
            //value1 is first number in display
            value1 = double.Parse(textDisplay.text);
            //add to textDisplay
            first = textDisplay.text;
            textDisplay.text = textDisplay.text + button;
            //operator has been hit and we aren't doing evaluation yet
            hitOp = true;
            hitequal = false;
        }
        //multiplication button hit  Note: Unity auto error handles if it is pressed before value 1 has anything)
        else if (button.Equals("x"))
        {
            op = button;
            //value1 is first number in display
            value1 = double.Parse(textDisplay.text);
            //add to textDisplay
            first = textDisplay.text;
            textDisplay.text = textDisplay.text + button;
            //operator has been hit and we aren't doing evaluation yet
            hitOp = true;
            hitequal = false;
        }
        //division button hit  Note: Unity auto error handles if it is pressed before value 1 has anything)
        else if (button.Equals("/"))
        {
            op = button;
            //value1 is first number in display
            value1 = double.Parse(textDisplay.text);
            //add to textDisplay
            first = textDisplay.text;
            textDisplay.text = textDisplay.text + button;
            //operator has been hit and we aren't doing evaluation yet
            hitOp = true;
            hitequal = false;
        }
        //mod button hit  Note: Unity auto error handles if it is pressed before value 1 has anything)
        else if (button.Equals("%"))
        {
            op = button;
            //value1 is first number in display
            value1 = double.Parse(textDisplay.text);
            //add to textDisplay
            first = textDisplay.text;
            textDisplay.text = textDisplay.text + button;
            //operator has been hit and we aren't doing evaluation yet
            hitOp = true;
            hitequal = false;
        }
        //equals button hit  Note: Unity auto error handles if it is pressed before anything is put in)
        else if (button.Equals("="))
        {
            //value2 is second number
            value2 = double.Parse(second);
            double final = 0;
            bool divZero = false;
            //operators
            switch (op)
            {
                case "+":
                    final = value1 + value2;
                    break;
                case "-":
                    final = value1 - value2;
                    break;
                case "x":
                    final = value1 * value2;
                    break;
                case "/":
                    //if dividing by zero
                    if(value2 == 0)
                    {
                        textDisplay.text = "DIV 0 ERROR";
                        divZero = true;
                    }
                    else
                    {
                        final = value1 / value2;
                    }
                    break;
                case "%":
                    //if dividing by zero
                    if (value2 == 0)
                    {
                        textDisplay.text = "DIV 0 ERROR";
                        divZero = true;
                    }
                    else
                    {
                        final = value1 % value2;
                    }
                    break;
                default:
                    //do nothing
                    break;
            }

            //if we aren't dividing by zero, it's fine!
            if(!divZero)
            {
                textDisplay.text = final.ToString();
            }
            
            //reset variables
            hitequal = true;
            second = "";
            op = "";
            hitOp = false;
        }
        //delete button hit  Note: Unity auto error handles if it is pressed before anything is put in)
        else if (button.Equals("Del"))
        {
            //if second is not empty
            if (!second.Equals(""))
            {
                second = second.Substring(0, second.Length - 1);
            }
            //if operator not empty
            else if (!op.Equals(""))
            {
                op = "";
                hitOp = false;
            }
            else if (!first.Equals("")) {
                first = first.Substring(0, first.Length - 1);
            }
            else
            {
                //do nothing
                first = "";
                second = "";
                op = "";

            }

            //revert back to previous display
            textDisplay.text = first + op + second;

        }
        //if not an operator
        else
        {
            //if we already did the equals operation, reset variables
            if (hitequal)
            {
                textDisplay.text = "";
                second = "";
                hitequal = false;
            }
            //if we got an operator, add second number to "second" variable
            if (hitOp)
            {
                //prevSecond = second;
                second = second + button;
            }
            else
            {
                first = textDisplay.text + button;
            }

            //put number to calc display
            textDisplay.text = textDisplay.text + button;
            

        }
    }
}
