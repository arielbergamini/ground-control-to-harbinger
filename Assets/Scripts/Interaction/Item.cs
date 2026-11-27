using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/Item", order = 1)]
public class Item : ScriptableObject
{
    public string id;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public int slotSize = 1; //how many slots an item takes up
}
