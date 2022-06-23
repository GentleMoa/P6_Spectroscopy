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
        else
        {
            Debug.Log("The touched object does not have a 'PhotonView' Component!");
        }
    }
}
