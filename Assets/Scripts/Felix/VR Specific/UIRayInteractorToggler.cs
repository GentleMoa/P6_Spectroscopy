//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A script toggling the VR player's UI ray interactor when inside/outside the research lab truck

using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UIRayInteractorToggler : MonoBehaviour
{
    //Private Variables
    private GameObject vrPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XROrigin>())
        {
            if (other.gameObject.GetComponent<XROrigin>() != null)
            {
                vrPlayer = other.gameObject.GetComponent<XROrigin>().gameObject;

                //Find UI Ray interactor in VR Player and ENABLE it
                vrPlayer.GetComponentInChildren<XRRayInteractor>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(vrPlayer != null)
        {
            //Find UI Ray interactor in VR Player and DISABLE it
            vrPlayer.GetComponentInChildren<XRRayInteractor>().enabled = false;
        }
    }
}
