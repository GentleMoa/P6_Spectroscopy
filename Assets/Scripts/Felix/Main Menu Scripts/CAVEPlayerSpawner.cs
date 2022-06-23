using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAVEPlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject menu_CAVEPlayer;
    [SerializeField] private Vector3 spawnPosition;

    public void SpawnMenuCAVEPlayer()
    {
        Instantiate(menu_CAVEPlayer, spawnPosition, Quaternion.identity);
    }
}
