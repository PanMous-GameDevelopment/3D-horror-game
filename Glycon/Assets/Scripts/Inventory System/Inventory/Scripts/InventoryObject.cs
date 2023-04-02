using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject 
{
    public List<InventorySlot> Container = new List<InventorySlot>(); // Creates a list for the inventory.
    // Adds item and its amount in the inventory.
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        { // Checks if the item already exists in the list. If it does, then it rises the amount of the item.
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount); // Rises the amount.
                hasItem = true;
                break;
            }
        } // If the list doesnt have the item, then it adds the item in the list creating a new slot with the new item and its amount.
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
    // Takes an item and removes it from the list.
    public void RemoveItem(ItemObject _item)
    {
        int i = 0;
        foreach (var x in Container) 
        { // If the received item exists in the list, it removes it and sets its amount to 0.
            if (Container[i].item == _item)
            {
                Container[i].UpdateSlot( null, 0);
                
            }
            i++;
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RemoveAmount(int value)
    {
        amount -= value;
    }

    public void UpdateSlot( ItemObject _item, int _amount)
    {
        
        item = _item;
        amount = _amount;
    }

}
