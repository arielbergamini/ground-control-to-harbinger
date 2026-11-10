using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public bool PlayerIn { get; private set; } //check that the player is inside the drop zone 


    void Start () { Debug.Log("dropzone active", this); }
    void OnTriggerEnter(Collider other)
    {

        Debug.Log($"dropZone entered by: {other.name}, tag: {other.tag}", other);
        if (!other.CompareTag("Player")) return; //drop zone logic only applies to the player
        Debug.Log("Player tag matches");
        PlayerIn = true;
        Deposit();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return; //drop zone logic only applies to the player, not any other game objects
        PlayerIn = false;
    }

    //take all items & send them to the persistent inventory
    public void Deposit()
    {
        List<Item> items = Inventory.Instance.TakeAllItems();
        Debug.Log($"Deposit took {items.Count} items");
        if (items.Count == 0) return;

        PersistentInventory.Instance.Add(items);
        Debug.Log("Deposit sent to persistent inventory");

        Inventory.Instance.Clear();
        Debug.Log("Cleared out inv dict. Current count: " + items.Count);
    }
}
