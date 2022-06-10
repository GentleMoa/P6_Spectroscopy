using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OwnershipHandler : MonoBehaviour
{
    private PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftController" || collision.gameObject.tag == "RightController")
        {
            //_photonView.TransferOwnership(Player requestingPlayer);
            _photonView.RequestOwnership();
        }
        else
        {
            Debug.Log("No Controller touched the ball but this object did:" + collision.gameObject.name);
        }
    }
}
