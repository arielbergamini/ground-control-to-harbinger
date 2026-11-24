using UnityEngine;

[CreateAssetMenu(fileName = "SpawnRules", menuName = "Scriptable Objects/SpawnRules")]
public class SpawnRules : ScriptableObject
{
    public GameObject prefab;
    public int min; //min/max spawn per level
    public int max;
    public BuildingType[] allowedBuildings; //where an item is allowed to spawn
}
