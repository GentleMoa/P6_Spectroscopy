//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 28.06.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAVECameraFixer : MonoBehaviour
{
    private PhotonView _photonView;
    private Camera[] _cameras;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _cameras = GetComponentsInChildren<Camera>();

        if (PhotonNetwork.InRoom && _photonView.IsMine)
        {
            foreach (Camera camera in _cameras)
            {
                camera.orthographic = true;
                camera.orthographic = false;
            }
        }
    }
}
