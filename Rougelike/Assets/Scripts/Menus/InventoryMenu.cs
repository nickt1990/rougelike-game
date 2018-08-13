using UnityEngine;

public class InventoryMenu : Menu
{
    public GameObject myItemSlot;
    private ItemSlot itemSlot;

    ItemSlot[,] itemSlots = new ItemSlot[2, 5];

    /// <summary>
    /// Creates the item slots in the inventory menu
    /// 
    /// CALLED BY: The InventoryMenu GameObject inside Unity.
    /// </summary>
    public void CreateSlots()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                itemSlot = new ItemSlot(Instantiate(myItemSlot));

                itemSlot.myGameObject.transform.SetParent(gameObject.transform);
                itemSlot.itemSlotSelector = itemSlot.myGameObject.gameObject.transform.GetChild(4);

                itemSlot.itemSlotSelector.gameObject.SetActive(false);

                itemSlots[i, j] = itemSlot;
                
            }
        }

        itemSlots[0,0].itemSlotSelector.gameObject.SetActive(true);
    }

}

public class ItemSlot
{
    public GameObject myGameObject;
    public Transform itemSlotSelector;

    public ItemSlot(GameObject itemSlot)
    {
        myGameObject = itemSlot;
    }

    public GameObject GetItemSlot()
    {
        return myGameObject;
    }

    public void ChangeSlotLocation(float x, float y)
    {
        myGameObject.transform.Translate(x, y, 0);
        
    }
}

