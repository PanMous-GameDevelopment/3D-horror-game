using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Egg Object", menuName = "Inventory System/Items/Egg")]
public class Egg : ItemObject
{
    public void Awake()
    {
        type = ItemType.Bandages;
    }
}
