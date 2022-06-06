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
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CAVEPlayerController"), Vector3.zero, Quaternion.identity);
            Debug.Log("Instantiated CavePlayer");
        }
        else
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "VRPlayerController"), Vector3.zero, Quaternion.identity);
            Debug.Log("Instantiated VrPlayer");
        }
        // Instantiate our playercontroller (VR or CAVE) + attach PhotonView to this prefab
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "INSERT PREFAB NAME HERE"), Vector3.zero, Quaternion.identity);
    }
}