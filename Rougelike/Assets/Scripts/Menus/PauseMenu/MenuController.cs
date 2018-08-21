using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void ClickInventoryButton()
    {
        InventoryMenu.inventoryMenu.SetActive(true);
    }
}

