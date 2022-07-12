//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A simple script for disabling the VR players camera and audio listener on the host's side

using Photon.Pun;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioListener _audioListener;
    private PhotonView _photonView;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.InRoom && !_photonView.IsMine)
        {
            _camera.enabled = false;
            _audioListener.enabled = false;
        }
    }
}