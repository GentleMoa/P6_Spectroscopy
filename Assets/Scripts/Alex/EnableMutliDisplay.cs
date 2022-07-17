//---------------------------------------------------------------------------------------------------------------//
//-------Alex Zarenko - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project ---------------------//
//---------------------------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMutliDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createMultiDisplay();
    }

    // finding all active displays and activating them (script provided by Grimm during an early lecture)
    void createMultiDisplay()

    {

        Debug.Log(Display.displays.Length);

        for (int i = 1; i < Display.displays.Length; i++)

            Display.displays[i].Activate();

    }
}
