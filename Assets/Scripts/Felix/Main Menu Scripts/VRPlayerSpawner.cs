using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject menu_VRPlayer;
    [SerializeField] private Vector3 spawnPosition;

    public void SpawnMenuVRPlayer()
    {
        Instantiate(menu_VRPlayer, spawnPosition, Quaternion.identity);
    }
}
