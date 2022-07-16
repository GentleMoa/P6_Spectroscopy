using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script has the purpose of spawning the Element-Prefabs, contained in an array, at a random position   //
//  on the terrain using a for-loop. It also spawns Rock-Prefabs on fixed positions across the terrain.        //

public class ElementSpawn : MonoBehaviour
{
    // Reference what should be spawned...
    public GameObject[] elements;
    public GameObject[] rocks;
    // ...and where:
    public Transform[] spawnPos;

    void Awake()
    {
        //SpawnElements();
        SpawnRocks();
    }

    private void SpawnElements()
    {
        if (PhotonNetwork.IsMasterClient) // Make sure it's not spawned twice (once per player)
        {
            // Spawn every element in the array once at a random position in a specific area on the terrain
            for (int i = 0; i < elements.Length; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10));
                PhotonNetwork.Instantiate(Path.Combine("PhotonElements", elements[i].name), spawnPos, Quaternion.identity);
            }
        }    
    }

    private void SpawnRocks()
    {
        if (PhotonNetwork.IsMasterClient) // Make sure it's not spawned twice (once per player)
        {
            // Spawn every element in the array inside a rock at fixed points on the terrain
            for (int i = 0; i < elements.Length; i++)
            {
                PhotonNetwork.Instantiate(Path.Combine("PhotonRocks", rocks[i].name), spawnPos[i].position, Random.rotation);
                PhotonNetwork.Instantiate(Path.Combine("PhotonElements", elements[i].name), spawnPos[i].position, Random.rotation);
            }
        }      
    }
}
