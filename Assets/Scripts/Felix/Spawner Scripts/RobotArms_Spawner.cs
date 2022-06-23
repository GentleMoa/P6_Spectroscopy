using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class RobotArms_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnRobotArms();
    }

    private void SpawnRobotArms()
    {
        //Spawning left Robot Arm
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RobotArm_L"), new Vector3(0.0f, 4.21f, 17.5f), Quaternion.identity * Quaternion.Euler(0.0f, 270.0f, 180.0f));
        //Spawning right Robot Arm
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RobotArm_R"), new Vector3(0.0f, 4.21f, 14.25f), Quaternion.identity * Quaternion.Euler(0.0f, 270.0f, 180.0f));
    }
}
