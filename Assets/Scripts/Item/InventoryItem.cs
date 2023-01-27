using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryItem : MonoBehaviour
{
    public int ItemId;
    public string name;
    public InventoryItem Item;
    public Sprite Icon;
    public int HealthAdded;
    public float SpeedAddition;
    public float EffectLast;
    public E_ItemType ItemType;
    public int Price;

}


public enum E_ItemType
{
    Heal = 0,
    Key = 1,
    Grenade = 2,
    Weapon = 3,
}
