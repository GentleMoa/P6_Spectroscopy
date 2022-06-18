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
            //Combined CAVE User with Camera Array and VR Controllers
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CAVEPlayerController_1"), new Vector3(-2.0f, 1.17f, 16.0f), Quaternion.identity * Quaternion.Euler(0.0f, 90.0f, 0.0f));
            //Robot Arm Controller Test VR Player
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_RobotArmTest"), new Vector3(-2.0f, 1.17f, 16.0f), Quaternion.identity);
            //Old CAVE User prefab
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CAVEPlayerController"), new Vector3(-2.0f, 1.17f, 16.0f), Quaternion.identity);
            //"Fake" CAVER User prefab (VR) in Truck
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_1"), new Vector3(-2.0f, 1.17f, 16.0f)/*new Vector3(0, 1, 0)*/, Quaternion.identity);
            //"Fake" CAVER User prefab (VR) outside
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_2"), new Vector3(0f, 0.5f, 0f), Quaternion.identity);

            Debug.Log("Instantiated CavePlayer");
        }
        else
        {
            //Correct VR Player Prefab to instantiate
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_2"), new Vector3(0f, 0f, 2f), Quaternion.identity);
            //Robot Arm Controller Test VR Player
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController_RobotArmTest"), new Vector3(0f, 0f, 2f), Quaternion.identity);
            //False VR Player?
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayer_Controller_2"), new Vector3(2, 1, 2), Quaternion.identity);
            Debug.Log("Instantiated VrPlayer");
        }
        // Instantiate our playercontroller (VR or CAVE) + attach PhotonView to this prefab
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "INSERT PREFAB NAME HERE"), Vector3.zero, Quaternion.identity);
    }
}
