using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Matches Object", menuName = "Inventory System/Items/Matches")]
public class Matches : ItemObject
{
    public void Awake()
    {
        type = ItemType.Matches;
    }
}
