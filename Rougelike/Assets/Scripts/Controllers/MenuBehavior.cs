using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuBehavior
{
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public KeyCode action;
    public KeyCode cancel;

    protected GameObject currentMenu;
    protected GameObject previousMenu;

    protected Button currentButton;
    protected Button previousButton;

    public abstract Menu GetCurrentMenu();

    public abstract void MoveDown();

    public abstract void MoveUp();

    public abstract void MoveLeft();

    public abstract void MoveRight();

    public void CheckInput()
    {
        if (Input.GetKeyDown(action))
        {
            PressEnter();
        }
        else if (Input.GetKeyDown(up))
        {
            MoveUp();
        }
        else if (Input.GetKeyDown(down))
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(left))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(right))
        {
            MoveRight();
        }
    }

    public void PressEnter()
    {
        currentButton.onClick.Invoke();
    }

    public void Back()
    {
        currentMenu.SetActive(false);
        previousMenu.SetActive(true);
    }

}

public class MainMenu : MenuBehavior
{
    private PauseMenu pauseMenu;

    private int currentIndex = 0;

    public MainMenu()
    {
        pauseMenu = new PauseMenu();
    }

    public override Menu GetCurrentMenu()
    {
        return pauseMenu;
    }

    public override void MoveDown()
    {
        if (currentIndex < pauseMenu.pauseMenuButtons.Length - 1)
        {
            previousButton = pauseMenu.pauseMenuButtons[currentIndex];
            previousButton.GetComponentInChildren<Text>().color = Color.white;

            currentIndex++;

            currentButton = pauseMenu.pauseMenuButtons[currentIndex];
            currentButton.GetComponentInChildren<Text>().color = Color.red;
        }
    }

    public override void MoveUp()
    {
        if (currentIndex > 0)
        {
            previousButton = pauseMenu.pauseMenuButtons[currentIndex];
            previousButton.GetComponentInChildren<Text>().color = Color.white;

            currentIndex--;

            currentButton = pauseMenu.pauseMenuButtons[currentIndex];
            currentButton.GetComponentInChildren<Text>().color = Color.red;
        }
    }

    public override void MoveLeft()
    {
        throw new NotImplementedException();
    }

    public override void MoveRight()
    {
        throw new NotImplementedException();
    }
}

public class InventoryBehavior : MenuBehavior
{
    private InventoryMenu inventoryMenu;

    public InventoryBehavior()
    {
        inventoryMenu = new InventoryMenu();
    }

    public override Menu GetCurrentMenu()
    {
        return inventoryMenu;
    }

    public override void MoveDown()
    {
        throw new NotImplementedException();
    }

    public override void MoveLeft()
    {
        throw new NotImplementedException();
    }

    public override void MoveRight()
    {
        throw new NotImplementedException();
    }

    public override void MoveUp()
    {
        throw new NotImplementedException();
    }
}

