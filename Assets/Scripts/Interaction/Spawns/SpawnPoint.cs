using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using UnityEngine;


//marker for where items are allowed to spawn
public class SpawnPoint : MonoBehaviour
{
    public BuildingType building; //which building this spot is in
    [HideInInspector] public bool used; //is this spot already occupied?

    //draws spawn points in scene; testing
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, .25f);
    }
    
}
