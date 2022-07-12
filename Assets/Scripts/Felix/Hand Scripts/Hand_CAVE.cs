//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

//Credit: "Fist Full of Shrimp" on Youtube: https://www.youtube.com/watch?v=qQqNQ4y-cU8&list=PLZxzW13nmdJE_HAMQEqTNk3BgYjedyfUX&index=3&t=31s, accessed 03.06.2022

// - - - UNUSED IN FINAL VERSION - - - //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using System.IO;

public class Hand_CAVE : MonoBehaviour
{
    //Stores what kind of characteristics we're looking for with our Input Device when we search for it later
    public InputDeviceCharacteristics inputDeviceCharacteristics_CAVE;

    //Stores the InputDevice that we're Targeting once we find it in InitializeHand()
    private InputDevice _targetDevice;
    private Animator _handAnimator;
    private GameObject _spawnedHand;

    private void Start()
    {
        InitializeHand();
    }

    private void InitializeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //Call InputDevices to see if it can find any devices with the characteristics we're looking for
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics_CAVE, devices);

        //Our hands might not be active and so they will not be generated from the search.
        //We check if any devices are found here to avoid errors.
        if (devices.Count > 0)
        {

            _targetDevice = devices[0];
            if (gameObject.tag == "LeftController")
            {
                //Instantiate Left hand here
                _spawnedHand = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "LeftHand_CAVE"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Invoke("ParentLeftHandPrefabToController", 0.1f);
                Debug.Log("LeftHand parented to Left Controller!");
                //Reset Position & Rotation to fit the Controller Pos & Rot
                //_spawnedHand.transform.localRotation = Quaternion.Euler(0.0f, -10.0f, 90.0f);
                //_spawnedHand.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                //_spawnedHand.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                _handAnimator = _spawnedHand.GetComponent<Animator>();
            }
            else if (this.gameObject.tag == "RightController")
            {
                //Instantiate Right hand here
                _spawnedHand = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RightHand_CAVE"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Invoke("ParentRightHandPrefabToController", 0.1f);
                Debug.Log("RightHand parented to Right Controller!");
                //Reset Position & Rotation to fit the Controller Pos & Rot
                //_spawnedHand.transform.localRotation = Quaternion.Euler(0.0f, 10.0f, -90.0f);
                //_spawnedHand.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                //_spawnedHand.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                _handAnimator = _spawnedHand.GetComponent<Animator>();
            }
        }
    }

    private void ParentLeftHandPrefabToController()
    {
        _spawnedHand.transform.SetParent(this.gameObject.transform);
        _spawnedHand.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        _spawnedHand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //(0.0f, -10.0f, 90.0f);
    }

    private void ParentRightHandPrefabToController()
    {
        _spawnedHand.transform.SetParent(this.gameObject.transform);
        _spawnedHand.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        _spawnedHand.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //(0.0f, 10.0f, -90.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        //Since our target device might not register at the start of the scene, we continously check until one is found.
        if (!_targetDevice.isValid)
        {
            InitializeHand();
        }
        else
        {
            UpdateHand();
        }
    }

    private void UpdateHand()
    {
        //This will get the value for our trigger from the target device and output a flaot into triggerValue
        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            _handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            _handAnimator.SetFloat("Trigger", 0);
        }
        //This will get the value for our grip from the target device and output a flaot into gripValue
        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            _handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            _handAnimator.SetFloat("Grip", 0);
        }
    }


}