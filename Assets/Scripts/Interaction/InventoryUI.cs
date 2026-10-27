using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class InventoryUI : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    GameObject uiItemPrefab;

    [Header("References")]
    [SerializeField]
    Inventory inventory;
    [SerializeField]
    Transform uiInventoryParent;

    [Header("State")]
    [Header("SerializeField")]
    SerializedDictionary<string, GameObject> inventoryUI = new();

    public void AddUIItem(string inventoryId, Item item)
    {
        var itemUI = Instantiate(uiItemPrefab).GetComponent<ItemUI>();
        inventoryUI.Add(inventoryId, itemUI.gameObject);
        itemUI.Initialize(inventoryId, item, inventory.DropItem);
    }

    public void RemoveUIItem(string inventoryId)
    {
        var itemUI = inventoryUI.GetValueOrDefault(inventoryId);
        inventoryUI.Remove(inventoryId);
        Destroy(itemUI);
    }
}
