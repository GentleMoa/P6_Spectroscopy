using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine) // checks if the PhotonView is owned by the Local Player
        {
            CreateController();
        }
    }

    void CreateController()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //CAVE Player with Vive Controllers (able to control Robot Arms)
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CAVE_Player_Controllers_V2"), new Vector3(-1.6f, 1.4f, 15.3f), Quaternion.identity * Quaternion.Euler(0.0f, 90.0f, 0.0f));

            //"Fake" CAVE User prefab (VR), for testing/debugging the Robot Arms!
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_RobotArmTest"), new Vector3(-2.0f, 1.17f, 16.0f), Quaternion.identity);

            //"Fake" CAVE User prefab (VR) outside [subsitute the spawn vector with: (-2.0f, 1.17f, 16.0f) if you want the "Fake" CAVE VR player to spawn inside the truck]
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_2"), new Vector3(0f, 0.5f, 0f), Quaternion.identity);

            Debug.Log("Instantiated CavePlayer");
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_2"), new Vector3(0f, 0f, 2f), Quaternion.identity);
        }
        else
        {
            //Correct VR Player Prefab to instantiate
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_2"), new Vector3(0f, 0f, 2f), Quaternion.identity);

            Debug.Log("Instantiated VrPlayer");
        }

        // Instantiate our playercontroller (VR or CAVE) + attach PhotonView to this prefab
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "INSERT PREFAB NAME HERE"), Vector3.zero, Quaternion.identity);
    }
}
