using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    //public int numCameras = 4;
    //public bool renderInTexture = true;

    // Start is called before the first frame update
    void Start() 
    {
        createMultiDisplay();
    }

    // rotY, rotX, lensshift

    float[,] cameraData = { { 0.0f, 0.0f, -0.5f }, { 0.0f, -90.0f, -0.5f }, { 0.0f, 90.0f, -0.5f }, { 90.0f, 0.0f, -0.5f },
                            { 0.0f, 0.0f, +0.5f }, { 0.0f, -90.0f, +0.5f }, { 0.0f, 90.0f, +0.5f }, { 90.0f, 0.0f, +0.5f }};


    void createMultiDisplay()
	{
        foreach (Display d in Display.displays) d.Activate();

    }
}
