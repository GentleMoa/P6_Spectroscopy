using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class XRInteractableNetworking : XRGrabInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonView _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(XRBaseInteractor _interactor)
    {
        //_photonView.RequestOwnership();
        base.OnSelectEntered(_interactor);
    }
}
