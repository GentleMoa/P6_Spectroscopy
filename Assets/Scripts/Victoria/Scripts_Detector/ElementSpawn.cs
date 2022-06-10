using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script has the purpose of spawning the Element-Prefabs contained in an array at a random position   //
//  on the terrain using a for-loop.                                                                         //

public class ElementSpawn : MonoBehaviour
{
    public GameObject[] elements;

    void Awake()
    {
        SpawnElements();
        //SpawnOne();
    }

    private void SpawnElements()
    {
        for(int i = 0; i < elements.Length-1; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(0, 40), 0.5f, Random.Range(0, 40));
            Instantiate(elements[i], spawnPos, Quaternion.identity);
        }
    }

    private void SpawnOne()
    {
            Vector3 spawnPos = new Vector3(Random.Range(0, 40), 0.5f, Random.Range(0, 40));
            Instantiate(elements[4], spawnPos, Quaternion.identity);
    }
}
