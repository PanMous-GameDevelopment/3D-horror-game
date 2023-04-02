using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sticks to the collectable items.
public class Item : MonoBehaviour
{
    public ItemObject item; // Item type.
    public InventoryObject inventory; // The inventory.

    public void OnMouseDown()
    {

        var item = GetComponent<Item>();

        inventory.AddItem(item.item, 1); // Adds the specific item to the inventory calling the AddItem() function.


    }

}

