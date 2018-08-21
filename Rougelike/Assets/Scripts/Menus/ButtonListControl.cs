﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour {

    [SerializeField]
    private GameObject buttonTemplate;

    public void AddButtons()
    {
        InventoryMenu.inventoryMenu.SetActive(true);

        for (int i = 1; i <= 20; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText("Button #" + i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
}
