using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CaveCameraManager : MonoBehaviour
{
    private Camera[] _cameras;
    private PhotonView _photonView;
    private AudioListener[] _audioListeners;
    // Start is called before the first frame update
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