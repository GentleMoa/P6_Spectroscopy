//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A script placed on the CAVE player, looking for the VR player's hands and parenting them to the VR player's controllers

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandChecker_CAVE : MonoBehaviour
{
    //Private Variables
    [SerializeField] private GameObject _leftController;
    [SerializeField] private GameObject _rightController;
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private bool _leftHandFound = false;
    [SerializeField] private bool _rightHandFound = false;
    [SerializeField] private bool _handsParented = false;
    //[SerializeField] private bool _handsReset = false;

    // Update is called once per frame
    void Update()
    {
        if (_leftHandFound == false || _rightHandFound == false)
        {
            _leftHand = GameObject.FindGameObjectWithTag("LeftHand_VR");
            _rightHand = GameObject.FindGameObjectWithTag("RightHand_VR");

            if (_leftHand != null)
            {
                _leftHandFound = true;
            }
            else if (_leftHand == null)
            {
                //Debug.Log("LeftHand Prefab has not been found yet!");
            }

            if (_rightHand != null)
            {
                _rightHandFound = true;
            }
            else if (_rightHand == null)
            {
                //Debug.Log("RightHand Prefab has not been found yet!");
            }
        }
        else if (_leftHandFound == true && _rightHandFound == true && _handsParented == false)
        {
            if (_leftHand.GetComponent<PhotonView>().IsMine == false && _rightHand.GetComponent<PhotonView>().IsMine == false)
            {
                //_leftController = GameObject.FindGameObjectWithTag("LeftController");
                //_rightController = GameObject.FindGameObjectWithTag("RightController");
                _leftController = GameObject.Find("LeftHand Controller_VR");
                _rightController = GameObject.Find("RightHand Controller_VR");

                Invoke("HandParenting", 1.0f);
            }
        }
    }

    private void HandParenting()
    {
        if (_leftController != null && _rightController != null)
        {
            //Parenting the hand prefabs to the controllers
            _leftHand.transform.SetParent(_leftController.transform);
            _rightHand.transform.SetParent(_rightController.transform);
            _handsParented = true;

            //resetting hands pos and rot
            _leftHand.transform.position = new Vector3(_leftController.transform.position.x, _leftController.transform.position.y, _leftController.transform.position.z);
            _leftHand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            _rightHand.transform.position = new Vector3(_rightController.transform.position.x, _rightController.transform.position.y, _rightController.transform.position.z);
            _rightHand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //_handsReset = true;
        }
        else
        {
            Debug.LogWarning("VR Controllers have not been found!");
        }
    }
}
