//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 28.06.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

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
            Debug.Log("Ownership WILL be requested by: " + collision.gameObject.name);
    
            _photonView.RequestOwnership();
    
            Debug.Log("Ownership HAS been requested by: " + collision.gameObject.name);
        }
        else
        {
            Debug.Log("No Controller touched the ball but this object did: " + collision.gameObject.name);
        }
    
    
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "LeftController" || other.gameObject.tag == "RightController")
    //    {
    //        Debug.Log("Ownership WILL be requested by: " + other.gameObject.name);
    //
    //        _photonView.RequestOwnership();
    //
    //        Debug.Log("Ownership HAS been requested by: " + other.gameObject.name);
    //    }
    //    else
    //    {
    //        Debug.Log("No Controller touched the ball but this object did: " + other.gameObject.name);
    //    }
    //}
}
