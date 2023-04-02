using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creating a custom type with the different object types for the game.
public enum ItemType
{
     Machete,
     Bandages,
     Matches,
     Egg
}
// Abstract class from which the items will inherent from.
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
