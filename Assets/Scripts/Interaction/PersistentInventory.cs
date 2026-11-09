using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using System.ComponentModel;
using System.Security.Cryptography;
public class PersistentInventory : MonoBehaviour
{
    public static PersistentInventory Instance {  get; private set; }
    SerializedDictionary<Item, int> owned = new(); //items currently in inv (scavenging scene)

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

        transform.SetParent(null); //verify this is a root game object
    }

    public void Add(List<Item> items)
    {
        foreach (Item item in items)
        {
            owned[item] = owned.GetValueOrDefault(item) + 1;
        }
    }

    public void Clear ()
    {
        owned.Clear();
    }
}
