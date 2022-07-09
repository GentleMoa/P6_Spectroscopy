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
    public GameObject[] elements;
    public GameObject[] rocks; // FILL IN ROCK-PREFABS ONCE THEY'VE BEEN CONSTRUCTED AND FILLED WITH ELEMENTS
    public Transform[] spawnPos; // RE-POSITION THEM IN THE SCENE ONCE THE PROPPER TERRAIN HAS BEEN BUILT BY ALEX

    void Awake()
    {
        //SpawnElements();
        SpawnRocks();
    }

    private void SpawnElements()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10));
            PhotonNetwork.Instantiate(Path.Combine("PhotonElements", elements[i].name), spawnPos, Quaternion.identity);
        }
    }

    private void SpawnRocks()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonRocks", rocks[i].name), spawnPos[i].position, Random.rotation); // FILL IN ROCK-PREFABS-FOLDER INSTEAD OF ELEMENTS
            PhotonNetwork.Instantiate(Path.Combine("PhotonElements", elements[i].name), spawnPos[i].position, Random.rotation);
        }
    }

    private void SpawnOne()
    {
        // spawn only one element at a random pos (for debugging purposes)
        Vector3 spawnPos = new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElement", elements[4].name), spawnPos, Quaternion.identity);
    }
}
