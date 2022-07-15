using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script enables a PoinLight and an emission-component on the lightbulb-material once the   //
//  multijuncion cell is placed inside the socket to show that the cell is "generating energy".    //

public class LghtbulbBehaviour : MonoBehaviour
{
    [SerializeField] private Light lightbulbLight;
    [SerializeField] private Material bulbMat;

    //private void Awake()
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        PhotonNetwork.Instantiate(Path.Combine("PhotonMachines", "PanelReader"), new Vector3(-3.3f, 1.086f, -2.8f), Quaternion.identity);
    //    }
    //}

    void Start()
    {
        // disable the light(bulb) on start 
        lightbulbLight.GetComponent<Light>().enabled = false;
        bulbMat.DisableKeyword("_EMISSION");
    }

    // enable the light(bulb) on multijunction-cell stay
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LayerJunction"))
        {
            lightbulbLight.GetComponent<Light>().enabled = true;
            bulbMat.EnableKeyword("_EMISSION");
        }
    }

    // enable the light(bulb) on multijunction-cell exit
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LayerJunction"))
        {
            lightbulbLight.GetComponent<Light>().enabled = false;
            bulbMat.DisableKeyword("_EMISSION");
        }
    }
}
