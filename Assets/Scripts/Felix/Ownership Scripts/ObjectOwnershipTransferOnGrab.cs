using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectOwnershipTransferOnGrab : MonoBehaviour
{
    public void ObjectOwnershipTransfer(PhotonView photonView)
    {
        photonView.RequestOwnership();
    }
}
