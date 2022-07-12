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

public class XRScriptsDisabler : MonoBehaviour
{
    private PhotonView _photonView;

    [Header("VR Player Variables")]
    [Header("")]

    [SerializeField] private XROrigin _vrPlayerXROrigin;
    [SerializeField] private ActionBasedController _leftHandXRController;
    [SerializeField] private ActionBasedController _rightHandXRController;
    [SerializeField] private XRDirectInteractor _leftHandXRInteractor;
    [SerializeField] private XRDirectInteractor _rightHandXRInteractor;
    [SerializeField] private ActionBasedController _teleportXRController;
    [SerializeField] private XRRayInteractor _teleportXRInteractor;
    [SerializeField] private CharacterControllerDriver _charControllerDriver;
    [SerializeField] private GameObject _locomotionSystemObj;
    [SerializeField] private GameObject _vrInputReaderObj;
    //[SerializeField] private Hand _leftHandScript;
    //[SerializeField] private Hand _rightHandScript;

    [Header("")]
    [Header("")]
    [Header("CAVE Player Variables")]
    [Header("")]

    [SerializeField] private EnableMutliDisplay _multiDisplayScript;
    [SerializeField] private GameObject _projectionPlanesObj;
    [SerializeField] private ActionBasedController _leftHandXRController_CAVE;
    [SerializeField] private ActionBasedController _rightHandXRController_CAVE;
    [SerializeField] private XRRayInteractor _leftHandXRInteractor_CAVE;
    [SerializeField] private XRRayInteractor _rightHandXRInteractor_CAVE;
    [SerializeField] private GameObject _locomotionSystemObj_CAVE;
    [SerializeField] private GameObject _vrInputReaderObj_CAVE;
    private ProjectionPlaneCamera[] _projPlaneCamScripts;
    //[SerializeField] private Hand _leftHandScript_CAVE;
    //[SerializeField] private Hand _rightHandScript_CAVE;



    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        if (this.gameObject.tag == "VRPlayer")
        {
            if (PhotonNetwork.InRoom && !_photonView.IsMine)
            {
                _vrPlayerXROrigin.enabled = false;
                _leftHandXRController.enabled = false;
                _rightHandXRController.enabled = false;
                _leftHandXRInteractor.enabled = false;
                _rightHandXRInteractor.enabled = false;
                _teleportXRController.enabled = false;
                _teleportXRInteractor.enabled = false;
                _charControllerDriver.enabled = false;
                _locomotionSystemObj.SetActive(false);
                _vrInputReaderObj.SetActive(false);
            }
        }
        else if (this.gameObject.tag == "CAVEPlayer")
        {
            if (PhotonNetwork.InRoom && !_photonView.IsMine)
            {
                _projPlaneCamScripts = GetComponentsInChildren<ProjectionPlaneCamera>();

                foreach (ProjectionPlaneCamera projectionPlaneCamera in _projPlaneCamScripts)
                {
                    projectionPlaneCamera.enabled = false;
                }

                _multiDisplayScript.enabled = false;
                _projectionPlanesObj.SetActive(false);
                _leftHandXRController_CAVE.enabled = false;
                _rightHandXRController_CAVE.enabled = false;
                _leftHandXRInteractor_CAVE.enabled = false;
                _rightHandXRInteractor_CAVE.enabled = false;
                _locomotionSystemObj_CAVE.SetActive(false);
                _vrInputReaderObj_CAVE.SetActive(false);
            }
        }
    }
}
