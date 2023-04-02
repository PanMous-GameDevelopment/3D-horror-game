using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bandages Object", menuName = "Inventory System/Items/Bandages")]
public class Bandages : ItemObject
{
    public void Awake()
    {
        type = ItemType.Bandages;
    }
}
