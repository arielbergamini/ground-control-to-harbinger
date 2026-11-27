using System.ComponentModel;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Item assets")]
    [SerializeField] Item foodItem, waterItem, ammoItem, fuelItem, medkitItem, organsItem, oxygenItem, ropeItem;
    [SerializeField] Item blasterItem, chemSetItem, flashlightItem, gpsItem, handbookItem, jukeboxItem, knifeItem, radioItem;
    [SerializeField] Item jackieItem, loganItem, steveItem, veraItem;

    public int food;
    public int water;
    public int ammo;
    public int fuel;
    public int medkit;
    public int organs; //Obtained during Scavenges or Random Events
    public int oxygen;
    public int rope;

    public bool blaster;
    public bool chemSet;
    public bool flashlight;
    public bool GPS;
    public bool handbook;
    public bool jukebox;
    public bool knife;
    public bool radio;

    public bool ASTRONAUT_jackie;
    public bool ASTRONAUT_logan;
    public bool ASTRONAUT_steve;
    public bool ASTRONAUT_vera;

    void Start()
    {
        PersistentInventory stash = PersistentInventory.Instance;
        if (stash == null)
        {
            Debug.LogWarning("PersistentInventory instance not found");
            return;
        }

        //astronaut debugging
        Debug.Log($"jackie slot: {(jackieItem == null ? "empty" : jackieItem.name)} | count: {stash.GetCount(jackieItem)}");
        Debug.Log($"logan slot: {(loganItem == null ? "empty" : loganItem.name)} | count: {stash.GetCount(loganItem)}");
        Debug.Log($"steve slot: {(steveItem == null ? "empty" : steveItem.name)} | count: {stash.GetCount(steveItem)}");
        Debug.Log($"vera slot: {(veraItem == null ? "empty" : veraItem.name)} | count: {stash.GetCount(veraItem)}");

        //Items stored as ints & bools map to a stash created from the persistent inventory object. they pull from the stash to reflect
        //inventory amounts in the journey scene!

        food = stash.GetCount(foodItem);
        water = stash.GetCount(waterItem);
        ammo = stash.GetCount(ammoItem);
        fuel = stash.GetCount(fuelItem);
        medkit = stash.GetCount(medkitItem);
        organs = stash.GetCount(organsItem); //Obtained during Scavenges or Random Events
        oxygen = stash.GetCount(oxygenItem);
        rope = stash.GetCount(ropeItem);

        blaster = stash.Has(blasterItem);
        chemSet = stash.Has(chemSetItem);
        flashlight = stash.Has(flashlightItem);
        GPS = stash.Has(gpsItem);
        handbook = stash.Has(handbookItem);
        jukebox = stash.Has(jukeboxItem);
        knife = stash.Has(knifeItem);
        radio = stash.Has(radioItem);

        ASTRONAUT_jackie = stash.Has(jackieItem);
        ASTRONAUT_logan = stash.Has(loganItem);
        ASTRONAUT_steve = stash.Has(steveItem);
        ASTRONAUT_vera = stash.Has(veraItem);
    }
}