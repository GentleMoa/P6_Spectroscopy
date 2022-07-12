//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A flawed script to disable items spawned twice due to multiplayer

// - - - UNUSED IN FINAL VERSION - - - //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MasterObjectsDestroyer : MonoBehaviour
{
    void Start()
    {
        //Checking if this gameobject belongs to the master's (CAVE) or the client's (VR) side of the multiplayer application
        if (PhotonNetwork.IsMasterClient)
        {
            //If it is the master's, destroy it to prevent doubles
            Destroy(this.gameObject);
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            //If it is the client's, preserve it
        }
    }
}
