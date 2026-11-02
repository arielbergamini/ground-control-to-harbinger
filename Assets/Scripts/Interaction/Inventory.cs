using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using System.ComponentModel;
using System.Security.Cryptography;

[RequireComponent(typeof(Collider))]
public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; } //Inventory self-reference; accessible thru Inventory.Instance

    [SerializeField]
    int maxCapacity = 4; //tweakable; inventory items CANNOT stack in scavenging scene!

    [Header("References")]
    [SerializeField]
    InventoryUI ui;
    [SerializeField]
    AudioSource audioSource;

    [Header("Prefabs")]
    [SerializeField]
    GameObject droppedItemPrefab;

    [Header("Audio Clips")]
    [SerializeField]
    AudioClip pickUpItemAudio;
    [SerializeField]
    AudioClip dropItemAudio;

    [Header("State")]
    [SerializeField]
    SerializedDictionary<string, Item> inventory = new(); //Items stored in dictionary

    void Awake()
    {
        //Guard against duplicate inventory instances
        if (Instance != null)
        {
            Debug.LogError("Inventory instance already exists");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("DroppedItem"))
        {
            return;
        }
        else //if we pick up an item we dropped before
        {
            var droppedItem = other.GetComponent<DroppedItem>();

            if (droppedItem == null || droppedItem.pickedUp)
            {
                return;
            }

            if (AddItem(droppedItem.item))
            {
                droppedItem.pickedUp = true;
            }

            AddItem(droppedItem.item);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(pickUpItemAudio);
        }
    }

    //add an item to the inventory on pickup
    public bool AddItem(Item item)
    {
        if (item == null)
        {
            Debug.LogError("Item not found");
            return false;
        }

        var inventoryId = Guid.NewGuid().ToString();

        //if inv not full, add the item; else, don't pick up
        if (inventory.Count >= maxCapacity)
        {
            Debug.LogError("Inventory is full!");
            return false;
        }
        else
        {
            inventory.Add(inventoryId, item);
            ui.AddUIItem(inventoryId, item);
            return true;
        }
    }

    //drop a selected item
    public void DropItem(string inventoryId)
    {
        var droppedItem = Instantiate(droppedItemPrefab, transform.position,
            Quaternion.identity).GetComponent<DroppedItem>();
        var item = inventory.GetValueOrDefault(inventoryId);
        droppedItem.Initialize(item);
        inventory.Remove(inventoryId);
        ui.RemoveUIItem(inventoryId);
        audioSource.PlayOneShot(dropItemAudio);
    }
}