using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This will allow us to get InputDevice
using UnityEngine.XR;

public class HardwareChecker : MonoBehaviour
{
    //Our main flags to tell us if we have HMD or CAVE harware connected
    [SerializeField] public bool hmdPresent = false;
    [SerializeField] public bool caveSetupPresent = false;

    //Creating a List of Input Devices to store our Input Devices in (we will only search for Input Devices with the Characteristic of "HeadMounted" to look for a HMD)
    List<InputDevice> inputDevices = new List<InputDevice>();

    //Reference to the inactive VR/CAVE player prefabs
    [SerializeField] private GameObject vrPlayer;
    [SerializeField] private GameObject cavePlayer;

    //Reference to the inactive XR Canvas
    [SerializeField] private GameObject xrCanvas;

    [Header("Time frame given to find a connected HMD")]
    //Time frame which is given to find the HMD
    [SerializeField] private float timeFrame = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckForHMD", 0.1f, 0.1f);
        CheckForCAVEsetup();

        Invoke("SpawnConditionalPlayer", timeFrame);
        Invoke("StopInvokes", timeFrame);
    }

    public void CheckForHMD()
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

    public void CheckForCAVEsetup()
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
        if (/*hmdPresent == true && */caveSetupPresent == false)
        {
            //Activate the corresponding player (VR)
            vrPlayer.SetActive(true);
        
            //Activate the XR Canvas
            xrCanvas.SetActive(true);
        }
        else if (/*hmdPresent == false && */caveSetupPresent == true)
        {
            //Activate the corresponding player (CAVE)
            cavePlayer.SetActive(true);

            //Activate the XR Canvas
            xrCanvas.SetActive(true);
        }
    }

    private void StopInvokes()
    {
        CancelInvoke();

        Debug.Log("All Invokes have been stopped!");
    }
}
