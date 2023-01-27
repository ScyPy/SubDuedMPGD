using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public int SlotIndex;
    public InventoryItem Item;
    public Image Icon;
    public Image UsedItemIcon;

    private void Start()
    {
        Icon = gameObject.GetComponent<Image>();
    }

    public void AddItem(InventoryItem item)
    {
        Icon.CrossFadeAlpha(1f, 0.1f, true);
        Icon.sprite = item.Icon;
        Item = item;
    }

    public void UsedItem()
    {
        StartCoroutine(ItemConsumedUI());
    }

    private IEnumerator ItemConsumedUI()
    {
        Color a = UsedItemIcon.color;
        a.a = 0.5f;
        UsedItemIcon.color = a;
        yield return new WaitForSeconds(0.1f);
        Color f = UsedItemIcon.color;
        f.a = 0f;
        UsedItemIcon.color = f;
    }

    public void RemoveItem()
    {
        Icon.CrossFadeAlpha(0.5f,0.1f, true);
        Icon.sprite = null;
        Item = null;
    }
}
