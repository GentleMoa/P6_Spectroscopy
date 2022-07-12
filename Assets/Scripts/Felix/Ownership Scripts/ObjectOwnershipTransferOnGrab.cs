//---------------------------------------------------------------------------------------------------------------//
//------- Provided by Torben Storch - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project -------//
//---------------------------------------------------------------------------------------------------------------//

// A simple script providing a owernship hand-over function, which can be called on (XR interactive) events to hand over ownership over an object to a player grabbing it

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//Call this function in the "XR Grab Interactable" component, under "Interactable Events" on "Select Entered"
public class ObjectOwnershipTransferOnGrab : MonoBehaviour
{
    public void ObjectOwnershipTransfer(PhotonView photonView)
    {
        photonView.RequestOwnership();
    }
}
