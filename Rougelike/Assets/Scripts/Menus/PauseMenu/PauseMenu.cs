using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : IMenu
{
    public static GameObject Menu = GameObject.Find("PauseMenu");

    public static Button[] buttons = Menu.GetComponentsInChildren<Button>();

    public static Button cmdInventory = buttons[0];
    public static Button cmdSkills = buttons[1];
    public static Button cmdStatus = buttons[2];

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

    public void InventoryMenuClick()
    {
        InventoryMenu.inventoryMenu.SetActive(true);
    }

    public void OpenMenu()
    {
        Menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
    }
}

