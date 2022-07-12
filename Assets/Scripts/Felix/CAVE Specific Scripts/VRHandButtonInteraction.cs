//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A simple script to call a physical button function when colliding with a controller hand (later we used socket interactors instead!)

// - - - UNUSED IN FINAL VERSION - - - //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandButtonInteraction : MonoBehaviour
{
    [SerializeField] ButtonScript _buttonScript;

    private void OnTriggerEnter(Collider other)
    {
        //Grabbing reference to the script in question
        _buttonScript = other.gameObject.GetComponent<ButtonScript>();

        if(other.gameObject.GetComponent<ButtonScript>() != null)
        {
            //Only for debugging purposes
            //Debug.Log("Button Script has been found!");

            //Setting the correct actions in the script
            _buttonScript.Pressed();
            _buttonScript.buttonPressed = true;
        }
        else
        {
            //Only for debugging purposes
            //Debug.Log("No Button script has been found!");
        }
    }
}
