using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class DetectorSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MaterialDetector"), new Vector3(1.0f, 0.7f, 7.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}