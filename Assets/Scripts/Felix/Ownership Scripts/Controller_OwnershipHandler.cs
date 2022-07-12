//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A flawed script, which attempted to hand over ownership to a user in the moment of grabbing a XR interactable
// Most likely, the problem was that this script is also called on the other player's side, so ownership is immediately returned to the original user

// - - - UNUSED IN FINAL VERSION - - - //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class Controller_OwnershipHandler : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PhotonView>() != null && other.gameObject.GetComponent<XRGrabInteractable>() != null)
        {
            _photonView = other.gameObject.GetComponent<PhotonView>();
            _photonView.RequestOwnership();
            Debug.Log(other.gameObject.name + " has been touched and owned by: " + this.gameObject.name);
        }
        else if (other.gameObject.GetComponent<PhotonView>() == null)
        {
            Debug.Log(other.gameObject.name + " does not have a 'PhotonView' component!");
        }
        else if (other.gameObject.GetComponent<XRGrabInteractable>() == null)
        {
            Debug.Log(other.gameObject.name + " does not have a 'XRGrabInteractable' component!");
        }
    }
}
