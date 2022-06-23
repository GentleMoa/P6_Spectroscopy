using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandButtonInteraction : MonoBehaviour
{
    [SerializeField] ButtonScript _buttonScript;

    private void OnTriggerEnter(Collider other)
    {
        _buttonScript = other.gameObject.GetComponent<ButtonScript>();

        Debug.Log(other.gameObject.name);

        if(other.gameObject.GetComponent<ButtonScript>() != null)
        {
            Debug.Log("Button Script has been found!");
            _buttonScript.Pressed();
            _buttonScript.buttonPressed = true;
            //_buttonScript.printingOngoing = true;
        }
        else
        {
            Debug.Log("No Button script has been found!");
        }
    }
}
