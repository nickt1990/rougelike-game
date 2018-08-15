using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public static class PauseMenu
{
    public static GameObject Menu = GameObject.Find("PauseMenu");

    static Button[] buttons = Menu.GetComponentsInChildren<Button>();

    public static Button ResumeButton = buttons[0];
    public static Button ExitButton = buttons[1];

    public static Text resumeText = ResumeButton.GetComponent<Text>();
    public static Text exitText = ExitButton.GetComponent<Text>();

    private static IControlBehavior Controls;

    static PauseMenu()
    {
              
    }

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

