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


    void createMultiDisplay()

    {

        Debug.Log(Display.displays.Length);

        for (int i = 1; i < Display.displays.Length; i++)

            Display.displays[i].Activate();

    }
}
