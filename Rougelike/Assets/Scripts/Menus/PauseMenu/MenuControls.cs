using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class MenuControls : IMovementBehavior
{
    private static PauseMenu pauseMenu = new PauseMenu();
    private static InventoryMenu inventoryMenu = new InventoryMenu();

    private IMenu currentMenu;
    private IMenu previousMenu;

    private Button previousButton;
    private Button currentButton;
    private int currentIndex;

    public MenuControls()
    {
        currentMenu = pauseMenu;
        pauseMenu.OpenMenu();
        inventoryMenu.CloseMenu();

        currentIndex = 0;
        currentButton = PauseMenu.buttons[currentIndex];
        currentButton.GetComponentInChildren<Text>().color = Color.red;
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
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            currentButton.onClick.Invoke();
        }

    }

    public IEnumerator SmoothMovement(Vector3 end)
    {
        throw new NotImplementedException();
    }
}

