using System.Collections;
using System.Security;
using System.Linq;
using UnityEngine;
using System.ComponentModel;
using System;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn rules (one asset for each item type)")]
    [SerializeField] SpawnRules[] rules; //the spawn rules for a particular item; will be modifiable in inspector for each item

    [Header("Debug")]
    [SerializeField] bool useFixedSeed;
    [SerializeField] int fixedSeed;

    void Start()
    {
        SpawnAll();
    }

    void SpawnAll() //spawn all items at game start
    {
        //items will need to spawn at game start once and only once
        //spawn qty and location dependent on level design ref sheet
        //random seeded spawns prevent duplicated runs

        //generate seed & log it in case anything weird happens
        int seed = useFixedSeed ? fixedSeed : Environment.TickCount;
        Debug.Log($"Seed: {seed}");
        var rng = new System.Random(seed);

        //gather potential spawn points & sort them
        List<SpawnPoint> allPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None).ToList();
        allPoints = allPoints.OrderBy(p => p.transform.position.x)
                                      .ThenBy(p => p.transform.position.z)
                                      .ThenBy(p => p.transform.position.y).ToList();
        foreach (SpawnPoint point in allPoints)
        {
            point.used = false;
        }

        //order spawn rules from pickiest to least picky; ie, jukebox, radio, and chem set can spawn in the fewest locations
        //so spawn them first, then everything else
        var sortedRules = rules.OrderBy(r => allPoints.Count(p => r.allowedBuildings.Contains(p.building))).ToList();

        //finally, spawn the items following one rules at a time
        foreach (SpawnRules rule in sortedRules)
        {
            int count = rng.Next(rule.min, rule.max + 1);

            List<SpawnPoint> eligibleSpawn = allPoints
                .Where(p => !p.used && rule.allowedBuildings.Contains(p.building))
                .ToList();

            if (eligibleSpawn.Count < rule.min)
            {
                Debug.LogWarning($"{rule.name}: wants at least {rule.min} but only {eligibleSpawn.Count} spots exist");
            }

            count = Mathf.Min(count, eligibleSpawn.Count);

            Shuffle(eligibleSpawn, rng);

            //item spawn orientation rotates on vertical axis for a random-looking feel
            for (int i = 0; i < count; i++) {
                Quaternion spinItem = Quaternion.Euler(0f, rng.Next(0, 360), 0f);

                Instantiate(
                    rule.prefab, 
                    eligibleSpawn[i].transform.position, 
                    spinItem * rule.prefab.transform.rotation
                 );
                eligibleSpawn[i].used = true;
            }
        }
    }

    static void Shuffle<T>(List<T> list, System.Random rng)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }


}
