//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A simple script to disable problematic inputs from the host's / client's side in multiplayer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using Unity.XR.CoreUtils;

public class XRInputDisabler : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private XROrigin _vrPlayerXROrigin;
    [SerializeField] private GameObject _vrCameraObject;
    [SerializeField] private GameObject _leftController;
    [SerializeField] private GameObject _rightController;
    [SerializeField] private GameObject _locomotionSystem_VR;
    [SerializeField] private GameObject _xrInteractionManager_VR;
    [SerializeField] private GameObject _xrActionInputManager_VR;
    [SerializeField] private GameObject _vrInputReader;

    void Start()
    {
        if (_photonView.IsMine)
        {
            Invoke("DisabelAllVRUsersXRScripts", 1.0f);
        }
    }
    private void DisabelAllVRUsersXRScripts()
    {
        //Disabling the VR XROrigin
        _vrPlayerXROrigin = FindObjectOfType<XROrigin>();
        if (_vrPlayerXROrigin != null)
        {
            _vrPlayerXROrigin.enabled = false;
        }
        else
        {
            Debug.LogWarning("No XROrigin was found nor disabled!");
        }

        //Disabling the VR Camera Object
        _vrCameraObject = GameObject.FindGameObjectWithTag("VRCameraOffset").gameObject.transform.GetChild(0).gameObject;
        if (_vrCameraObject != null /* && _vrCameraObject.gameObject.tag == "MainCamera" */)
        {
            _vrCameraObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No VR Camera Object was found nor disabled!");
        }

        //Left Controller
        _leftController = GameObject.FindGameObjectWithTag("LeftController");
        if (_leftController != null)
        {
            //Disabling Left Controller Input Scripts
            _leftController.GetComponent<ActionBasedController>().enabled = false;
            _leftController.GetComponent<XRDirectInteractor>().enabled = false;

            //Disabling Left Teleport Ray Input Scripts
            _leftController.transform.GetChild(0).gameObject.GetComponent<ActionBasedController>().enabled = false;
            _leftController.transform.GetChild(0).gameObject.GetComponent<XRRayInteractor>().enabled = false;
        }
        else
        {
            Debug.LogWarning("No Left VR Controller was found nor disabled!");
        }

        //Right Controller
        _rightController = GameObject.FindGameObjectWithTag("RightController");
        if (_rightController != null)
        {
            //Disabling Right Controller Input Scripts
            _rightController.GetComponent<ActionBasedController>().enabled = false;
            _rightController.GetComponent<XRDirectInteractor>().enabled = false;
        }
        else
        {
            Debug.LogWarning("No Right VR Controller was found nor disabled!");
        }

        //Disabling Other VR specific Scripts
        _locomotionSystem_VR = GameObject.Find("Locomotion System_VR");
        _locomotionSystem_VR.SetActive(false);
        _xrInteractionManager_VR = GameObject.Find("XR Interaction Manager_VR");
        _xrInteractionManager_VR.SetActive(false);
        _xrActionInputManager_VR = GameObject.Find("XR Action Input Manager_VR");
        _xrActionInputManager_VR.SetActive(false);
        _vrInputReader = GameObject.Find("VRInputReader");
        _vrInputReader.SetActive(false);
    }
}
