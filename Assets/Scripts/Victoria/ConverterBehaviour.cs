using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script handles the following functionalities of the converter-machine: determine OnTriggerEnter which element has been         //
//  put into the converter-machine and Photon.Instanciate the corresponding junction layer by calling the element's scriptable object   //

public class ConverterBehaviour : MonoBehaviour
{
    private Vector3 testSpawnPos = new Vector3(-1f, 0.5f, -4.5f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Element")) // REPLACE TAG WITH "CollectedElement" WHICH THE ELEMENT WILL HAVE AFTER IT'S BEEN PICKED UP
        {
            string layer = other.GetComponent<SOHolder>().element.layer.name;

            if (PhotonNetwork.IsMasterClient){

                PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", layer), transform.position, Quaternion.identity);
                Debug.Log("Layer is printed!");
            }

            Destroy(other.gameObject);
            Debug.Log("Element is destroyed!");

        }
    }
}