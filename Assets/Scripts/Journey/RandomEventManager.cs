using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class RandomEventManager : MonoBehaviour
{
    public int journeyLength = 100;

    [Header("STANDARD EVENTS")]
    public int standardEvents = 100;

    [Header("COMMON EVENTS")]
    public int powerOutage = 50;
    
    [Header("SEMI-COMMON EVENTS")]
    public int strangersBad = 13;
    public int strangersGood = 13; // Increased by Jackie's Presence
    public int engineMalfunction = 24;
    
    [Header("UNCOMMON EVENTS")]
    public int asteroids = 7;
    public int groundControl = 7;
    public int sickness = 7;
    public int supplyDrop = 7; // Increased by Jackie's presence
    
    [Header("RARE EVENTS")]
    public int shootingStar = 3; // Increased by Jackie's presence
    public int UFOAttack = 3;
    
    [Header("ULTRARARE EVENTS")]
    public int rescue = 1;


     enum RandomEvent
    {
        Standard,
        Power,
        StrangerBad,
        StrangerGood,
        Engine,
        Asteroid,
        Ground,
        Sickness,
        Supply,
        Star,
        UFO,
        Rescue,
        Arrive
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //int total = standardEvents + powerOutage + strangersBad + strangersGood + engineMalfunction
        //    + asteroids + groundControl + sickness + supplyDrop + shootingStar + UFOAttack + rescue;

        List<RandomEvent> MasterEventList = new List<RandomEvent>();
        List<RandomEvent> JourneyEventList = new List<RandomEvent>();

        // Adds each type of event to a list a given number of times
        AddEventsToList(RandomEvent.Standard, standardEvents, MasterEventList);
        AddEventsToList(RandomEvent.Power, powerOutage, MasterEventList);
        AddEventsToList(RandomEvent.StrangerBad, strangersBad, MasterEventList);
        AddEventsToList(RandomEvent.StrangerGood, strangersGood, MasterEventList);
        AddEventsToList(RandomEvent.Engine, engineMalfunction, MasterEventList);
        AddEventsToList(RandomEvent.Asteroid, asteroids, MasterEventList);
        AddEventsToList(RandomEvent.Ground, groundControl, MasterEventList);
        AddEventsToList(RandomEvent.Sickness, sickness, MasterEventList);
        AddEventsToList(RandomEvent.Supply, supplyDrop, MasterEventList);
        AddEventsToList(RandomEvent.Star, shootingStar, MasterEventList);
        AddEventsToList(RandomEvent.UFO, UFOAttack, MasterEventList);
        AddEventsToList(RandomEvent.Rescue, rescue, MasterEventList);

        // Shuffle all events
        Shuffle(MasterEventList);

        // Creates a list of events on the Journey; Final event is arrival/win
        for (int i = 0; i < journeyLength-2; i++)
        {
            JourneyEventList.Add(MasterEventList[i]);
        }
        JourneyEventList.Add(RandomEvent.Arrive);

        // Print list of events on the Journey
        PrintList(JourneyEventList);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddEventsToList(RandomEvent randomEvent, int amount, List<RandomEvent> list)   // Adds an amount of RandomEvents to a given list
    {
        for (int i = 0; i < amount; i++)
        {
            list.Add(randomEvent);
        }
    }

    void PrintList(List<RandomEvent> list) // Prints any given list
    {
        foreach (var item in list)
        {
            Debug.Log(item.ToString());
        }
    }

    public static void Shuffle<T>(IList<T> ts)  // Shuffles any given list
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; i++)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
