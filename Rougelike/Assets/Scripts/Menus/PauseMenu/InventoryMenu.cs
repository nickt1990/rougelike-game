using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InventoryMenu : IMenu
{
    public static GameObject inventoryMenu = GameObject.Find("Inventory_Menu");

    public void OpenMenu()
    {
        inventoryMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
    }
}

