//Credit: "Fist Full of Shrimp" on Youtube: https://www.youtube.com/watch?v=qQqNQ4y-cU8&list=PLZxzW13nmdJE_HAMQEqTNk3BgYjedyfUX&index=3&t=31s, accessed 03.06.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using System.IO;

public class Hand : MonoBehaviour
{
    //Stores handPrefab to be Instantiated
    public GameObject handPrefab;

    //Stores what kind of characteristics we're looking for with our Input Device when we search for it later
    public InputDeviceCharacteristics inputDeviceCharacteristics;

    //Stores the InputDevice that we're Targeting once we find it in InitializeHand()
    private InputDevice _targetDevice;
    private Animator _handAnimator;


    private void Start()
    {
        InitializeHand();
    }

    private void InitializeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //Call InputDevices to see if it can find any devices with the characteristics we're looking for
        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        //Our hands might not be active and so they will not be generated from the search.
        //We check if any devices are found here to avoid errors.
        if (devices.Count > 0)
        {

            _targetDevice = devices[0];
            if (gameObject.tag == "LeftHand")
            {
                //Instantiate Left hand here
                GameObject spawnedHand = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "LeftHand"), Vector3.zero, Quaternion.identity);
                _handAnimator = spawnedHand.GetComponent<Animator>();
                spawnedHand.transform.parent = this.gameObject.transform;
            }
            else if (this.gameObject.tag == "RightHand")
            {
                //Instantiate Right hand here
                GameObject spawnedHand = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "RightHand"), Vector3.zero, Quaternion.identity);
                _handAnimator = spawnedHand.GetComponent<Animator>();
                spawnedHand.transform.parent = this.gameObject.transform;
            }
        }
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