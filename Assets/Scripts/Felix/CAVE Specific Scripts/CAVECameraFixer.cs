//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A simple script to fix CAVE player camera issues

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAVECameraFixer : MonoBehaviour
{
    private PhotonView _photonView;
    private Camera[] _cameras;

    void Start()
    {
        //This is run in order to fix camera issues the CAVE player had. Enabling and immediately disabling orthographic mode fixed it.

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
