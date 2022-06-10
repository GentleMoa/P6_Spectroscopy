using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball_1 (Instantaneous)"), new Vector3(-0.4f, 0.85f, -0.9f), Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball_2 (Kinematic)"), new Vector3(0.0f, 0.85f, -0.9f), Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball_3 (Velocity Tracking)"), new Vector3(0.4f, 0.85f, -0.9f), Quaternion.identity);
    }
}
