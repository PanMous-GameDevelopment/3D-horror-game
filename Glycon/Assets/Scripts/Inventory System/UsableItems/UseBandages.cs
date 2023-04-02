using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBandages : MonoBehaviour
{
    public float healAmount;
    public InventoryObject inventory;
    public ItemObject itemBandages;
    public int amountToRemove;

    public AudioSource useBandagesAudio;

    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.E))
        {
            int i = 0;
            // For each item in inventory it checks if there are bandage items in the inventory.
            foreach (var x in inventory.Container)
            {
                if (inventory.Container[i].item == itemBandages)
                { // If it exists and its amount is > 0 then heal the player and remove 1 amount of the item from the inventory.
                    if (inventory.Container[i].amount > 0)
                    {
                        useBandagesAudio.Play();
                        FirstPersonController.OnTakeHeal(healAmount);
                        inventory.Container[i].RemoveAmount(amountToRemove);
                    }
                }
                i++;
            }            
        }
    }    
}
