//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 28.06.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

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
