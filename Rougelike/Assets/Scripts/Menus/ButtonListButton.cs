using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    Text myText;

    public void SetText(string myString)
    {
        myText.text = myString;
    }
}
