using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This will allow us to get InputDevice
using UnityEngine.XR;

public class HardwareChecker : MonoBehaviour
{
    //Our main flags to tell us if we have HMD or CAVE harware connected
    [SerializeField] private bool hmdPresent = false;
    [SerializeField] private bool caveSetupPresent = false;

    //Creating a List of Input Devices to store our Input Devices in (we will only search for Input Devices with the Characteristic of "HeadMounted" to look for a HMD)
    List<InputDevice> inputDevices = new List<InputDevice>();

    //References to the VR/CAVE player spawner scripts
    private CAVEPlayerSpawner _cavePlayerSpawner;
    private VRPlayerSpawner _vrPlayerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        //Find the VR/CAVE player spawner scripts
        _cavePlayerSpawner = GameObject.FindObjectOfType<CAVEPlayerSpawner>();
        _vrPlayerSpawner = GameObject.FindObjectOfType<VRPlayerSpawner>();

        if(_cavePlayerSpawner == null || _vrPlayerSpawner == null)
        {
            Debug.Log("The conditional player spawner scripts have not been found!");
        }

        CheckForHMD();
        CheckForCAVEsetup();

        Invoke("SpawnConditionalPlayer", 0.5f);
    }

    private void CheckForHMD()
    {
        //Fill the list with all devices found that match the characteristic of "HeadMounted" (usually only HMDs)
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeadMounted, inputDevices);

        if (inputDevices.Count > 0)
        {
            Debug.Log("Following head-mounted XR devices have been found: ");

            foreach (var inputDevice in inputDevices)
            {
                Debug.Log(inputDevice.name); 
            }

            //Set the hmdPresent flag, which will be used to determine what player prefab to spawn to true
            hmdPresent = true;
        }
        else if (inputDevices.Count < 1)
        {
            Debug.Log("No head-mounted XR devices have been found!");

            //Set the hmdPresent flag, which will be used to determine what player prefab to spawn to false
            hmdPresent = false;
        }
    }

    private void CheckForCAVEsetup()
    {
        //Checking the amount of connected displays ! ! ! - Only works in builds, not in the Unity Editor - ! ! !
        if (Display.displays.Length > 5)
        {
            Debug.Log("There are at least 6 displays connected, it is assumed that you run this build via a CAVE setup!");

            //Set the caveSetupPresent flag, which will be used to determine what player prefab to spawn to true
            caveSetupPresent = true;
        }
        else if (Display.displays.Length < 5)
        {
            Debug.Log("Less than 6 displays are connected, it is assumed that you DO NOT run this build via a CAVE setup!");

            //Set the caveSetupPresent flag, which will be used to determine what player prefab to spawn to true
            caveSetupPresent = false;
        }
    }

    private void SpawnConditionalPlayer()
    {
        if (hmdPresent == true && caveSetupPresent == false)
        {
            //Executed when the hardware checker found a HMD and less than 6 displays
            _vrPlayerSpawner.SpawnMenuVRPlayer();

        }
        else if (hmdPresent == false && caveSetupPresent == true)
        {
            //Executed when the hardware checker found no HMD and at least 6 displays
            _cavePlayerSpawner.SpawnMenuCAVEPlayer();
        }
    }
}
