using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuControls : IMovementBehavior
{
    public void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PauseMenu.resumeText.color = Color.white;
            PauseMenu.exitText.color = Color.red;
        }
    }

    public IEnumerator SmoothMovement(Vector3 end)
    {
        throw new NotImplementedException();
    }
}

