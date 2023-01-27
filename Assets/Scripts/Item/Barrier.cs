using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Barrier : MonoBehaviour
{
    public int BarrierID;
    public int Price;
    public int Health;
    public GameObject Prefab;
    public GameObject VFXDestruction;
    public Transform SpawnPos;
    public BuyingStation BuyStation;

    private void Update()
    {
        if (Health <= 0)
        {
            ActivateBarrierOption();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
    }

    private void ActivateBarrierOption()
    {
        BuyStation.HasBarrier = false;
    }
}
//public enum E_BuyableItem
//{
//    Weapon = 0,
//    Barrier = 1,
//    InventoryItem = 2,
//}
