using Photon.Pun;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioListener _audioListener;
    private PhotonView _photonView;
    // Start is called before the first frame update
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