//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.07.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

// A script resetting the VR player's height so that it matches with a proper height the floor

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer_HeightResetter : MonoBehaviour
{
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Invoke("ResetPlayerHeight", 0.5f);
    }

    private void ResetPlayerHeight()
    {
        //This line is necessary to reset the VR player's height to a proper level
        _characterController.center = new Vector3(0.0f, 1.0f, 0.0f);
    }
}
