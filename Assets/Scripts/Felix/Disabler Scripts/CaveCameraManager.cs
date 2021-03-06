//---------------------------------------------------------------------------------------------------------------//
//------- Provided by Philipp Petry - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project -------//
//---------------------------------------------------------------------------------------------------------------//

// A simple script to disable the CAVE player's cameras & audio listeners on the client's side

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CaveCameraManager : MonoBehaviour
{
    private Camera[] _cameras;
    private PhotonView _photonView;
    private AudioListener[] _audioListeners;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _cameras = GetComponentsInChildren<Camera>();
        _audioListeners = GetComponentsInChildren<AudioListener>();

        if (PhotonNetwork.InRoom && !_photonView.IsMine)
        {
            foreach (Camera camera in _cameras)
            {
                camera.enabled = false;
            }
            foreach (AudioListener audioListner in _audioListeners)
            {
                audioListner.enabled = false;
            }
        }
    }
}