using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DoubleObjectDestroyer : MonoBehaviour
{
    private PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = this.gameObject.GetComponent<PhotonView>();

        if (_photonView != null)
        {
            if (_photonView.IsMine == false)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("This Gameobject is missing the 'PhotonView' component!");
        }
    }

}
