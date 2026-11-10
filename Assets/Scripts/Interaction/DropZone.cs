using System.Collections.Generic;
using System.ComponentModel;
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

        //what did we drop off?
        string summary = BuildItemSummary(items);
        if (PopupController.Instance != null)
        {
            PopupController.Instance.Show("Dropped off:\n" + summary);
        }

    }

    //tell player what they dropped off at the ship
    string BuildItemSummary(List<Item> items)
    {
        Dictionary<Item, int> itemCounts = new Dictionary<Item, int>();
        foreach (Item item in items)
        {
            itemCounts[item] = itemCounts.GetValueOrDefault(item) + 1;
        }

        List<string> tally = new List<string>();
        foreach (var pair in itemCounts)
        {
            tally.Add($"{pair.Value}x {pair.Key.name}");
        }

        return string.Join("\n", tally);
    }
}
