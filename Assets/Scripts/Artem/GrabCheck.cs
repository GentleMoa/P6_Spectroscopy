// Created by Artem Brodetskii 14.06.22 //
// Checks whether the solar panel layer is gripped //
//--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour
{
    public bool grabbed = false;
    // Start is called before the first frame update
    public void Grabbed()
    {
        grabbed = true;
    }
    public void UnGrabbed()
    {
        grabbed = false;
    }
}
