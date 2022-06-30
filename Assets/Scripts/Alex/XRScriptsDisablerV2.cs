using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using Unity.XR.CoreUtils;

public class XRScriptsDisablerV2 : MonoBehaviour
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

    [SerializeField] private CameraRig _cameraRig_CAVE;
    [SerializeField] private ActionBasedController _leftHandXRController_CAVE;
    [SerializeField] private ActionBasedController _rightHandXRController_CAVE;
    [SerializeField] private XRRayInteractor _leftHandXRInteractor_CAVE;
    [SerializeField] private XRRayInteractor _rightHandXRInteractor_CAVE;
    [SerializeField] private GameObject _locomotionSystemObj_CAVE;
    [SerializeField] private GameObject _vrInputReaderObj_CAVE;
    private cavescreen[] _cavescreens;
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
                _cavescreens = GetComponentsInChildren<cavescreen>();

                foreach (cavescreen caveScreen in _cavescreens)
                {
                    caveScreen.enabled = false;
                }

                _cameraRig_CAVE.enabled = false;
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

