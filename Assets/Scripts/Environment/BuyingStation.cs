using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingStation : MonoBehaviour
{
    public E_BuyingStation StationType;
    public Weapon Weapon;
    public Barrier Barrier;
    public InventoryItem InventoryItem;
    public Door Door;
    public Transform BarrierSpawn;
    public bool HasBarrier;
}

public enum E_BuyingStation
{
    Barrier = 0,
    Weapon = 1,
    InventoryItem = 2,
    Door = 3,
}