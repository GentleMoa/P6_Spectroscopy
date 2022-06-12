using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

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
        Vector3 spawnPos = new Vector3(Random.Range(0, 20), 1.0f, Random.Range(0, 20));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElements", "GaAs (Gallium_Arsenide)"), spawnPos, Quaternion.identity);
        spawnPos = new Vector3(Random.Range(0, 20), 1.0f, Random.Range(0, 20));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElements", "GaInAs (Galluim_Induim_Arsenide)"), spawnPos, Quaternion.identity);
        spawnPos = new Vector3(Random.Range(0, 20), 1.0f, Random.Range(0, 20));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElements", "GaInNAs (Galluim_Induim_Nitrogen_Arsenide)"), spawnPos, Quaternion.identity);
        spawnPos = new Vector3(Random.Range(0, 20), 1.0f, Random.Range(0, 20));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElements", "GaInP (Galluim_Induim_Phosphate)"), spawnPos, Quaternion.identity);
        spawnPos = new Vector3(Random.Range(0, 20), 1.0f, Random.Range(0, 20));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElements", "Ge (Germanium)"), spawnPos, Quaternion.identity);
        spawnPos = new Vector3(Random.Range(0, 20), 1.0f, Random.Range(0, 20));
        PhotonNetwork.Instantiate(Path.Combine("PhotonElements", "Si (Silicon)"), spawnPos, Quaternion.identity);

        //for(int i = 0; i < elements.Length-1; i++)
        //{
        //    Vector3 spawnPos = new Vector3(Random.Range(0, 40), 0.5f, Random.Range(0, 40));
        //    //Instantiate(elements[i], spawnPos, Quaternion.identity);
        //}
    }

    private void SpawnOne()
    {
            Vector3 spawnPos = new Vector3(Random.Range(0, 40), 0.5f, Random.Range(0, 40));
            Instantiate(elements[4], spawnPos, Quaternion.identity);
    }
}
