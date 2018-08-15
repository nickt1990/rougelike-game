using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class MenuControls : IControlBehavior
{
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode up = KeyCode.UpArrow;

    public void CheckInput()
    {

        if (Input.GetKeyDown(down))
        {

        }

        throw new NotImplementedException();
    }
}

