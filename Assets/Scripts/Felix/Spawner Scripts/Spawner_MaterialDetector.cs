//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A very simple script to spawn a object (Material Detector)

// - - - UNUSED IN FINAL VERSION - - - //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Spawner_MaterialDetector : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "MaterialDetector"), transform.position, Quaternion.identity);
    }
}
