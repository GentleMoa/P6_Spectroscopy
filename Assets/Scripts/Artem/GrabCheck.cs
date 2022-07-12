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
