using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu
{
    public static GameObject Menu = GameObject.Find("PauseMenu");

    public static Button[] buttons = Menu.GetComponentsInChildren<Button>();

    public static Button cmdInventory = buttons[0];
    public static Button cmdSkills = buttons[1];
    public static Button cmdStatus = buttons[2];

    private static IControlBehavior Controls;

    public static void SetControlBehavior(IControlBehavior cb)
    {
        Controls = cb;
    }

    public static void CheckInput()
    {

    }

    public static void resumeButtonClick()
    {
        Time.timeScale = 1;
    }

    public static void exitButtonClick()
    {

    }
}

