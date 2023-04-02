using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Machete Object", menuName = "Inventory System/Items/Machete")]
public class Machete : ItemObject
{
    public void Awake()
    {
        type = ItemType.Bandages;
    }
}
