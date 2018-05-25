using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour {


    public GameObject itemSlotPrefab;
    public GameObject content;
    public ToggleGroup itemSlotToggleGroup;

    private GameObject itemSlot;

    //private int xPos;
    private int xPos;
    private int yPos;

	// Use this for initialization
	void Start ()
    {
        CreateInventorySlotsInWindow();
	}

    private void CreateInventorySlotsInWindow()
    {
        for (int i = 0; i < 10; i++) // GameObject find and look at the players inventory and get the count of the inventory
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = i.ToString();

            itemSlot.transform.SetParent(content.transform);

            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);

            yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.height;
            xPos = (int)itemSlot.GetComponent<RectTransform>().rect.width;

        }
    }
}
