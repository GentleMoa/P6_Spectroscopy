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

    void Start()
    {
        // Disable the light(bulb) on start 
        lightbulbLight.GetComponent<Light>().enabled = false; // Disable the PointLight inside the Lightbulb
        bulbMat.DisableKeyword("_EMISSION");                  // Disable emmision on the lightbulb's material
    }

    // Enable the light(bulb) once the multijunction-cell (with the right tag) enters the collider
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LayerJunction"))
        {
            lightbulbLight.GetComponent<Light>().enabled = true; // Enable the PointLight inside the Lightbulb to show that the manufactured multijunction-cell is working, yay!
            bulbMat.EnableKeyword("_EMISSION");                  // Enable emmision on the lightbulb's material
        }
    }

    // Disable the light(bulb) once the multijunction-cell (with the right tag) exits the collider again
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LayerJunction"))
        {
            lightbulbLight.GetComponent<Light>().enabled = false; // Disable the PointLight inside the Lightbulb
            bulbMat.DisableKeyword("_EMISSION");                  // Disable emmision on the lightbulb's material
        }
    }
}
