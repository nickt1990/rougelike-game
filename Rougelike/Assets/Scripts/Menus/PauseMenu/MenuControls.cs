using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class MenuControls : IMovementBehavior
{
    private static PauseMenu pauseMenu;

    private Button previousButton;
    private Button currentButton;
    private int currentIndex;

    public MenuControls()
    {
        currentIndex = 0;
        currentButton = PauseMenu.buttons[currentIndex];
        currentButton.GetComponentInChildren<Text>().color = Color.red;
    }

    public void CheckInput(int sweetSpot)
    {
        throw new NotImplementedException();
    }

    public void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentIndex < PauseMenu.buttons.Length - 1)
        {
            currentIndex++;

            previousButton = currentButton;
            previousButton.GetComponentInChildren<Text>().color = Color.white;

            currentButton = PauseMenu.buttons[currentIndex];
            currentButton.GetComponentInChildren<Text>().color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && currentIndex > 0)
        {
            currentIndex--;

            previousButton = currentButton;
            previousButton.GetComponentInChildren<Text>().color = Color.white;

            currentButton = PauseMenu.buttons[currentIndex];
            currentButton.GetComponentInChildren<Text>().color = Color.red;
        }

    }

    public IEnumerator SmoothMovement(Vector3 end)
    {
        throw new NotImplementedException();
    }
}

