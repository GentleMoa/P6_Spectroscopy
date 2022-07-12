//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A flawed script to disable items spawned twice due to multiplayer

// - - - UNUSED IN FINAL VERSION - - - //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DoubleObjectDestroyer : MonoBehaviour
{
    private PhotonView _photonView;

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
