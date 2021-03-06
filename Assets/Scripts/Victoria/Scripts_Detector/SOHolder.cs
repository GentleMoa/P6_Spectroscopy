using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script has the simple purpose of holding the scriptable object (SO) on each Element-Prefab so it's data         //
//  can be accessed by UI-elements through other scripts (e.g. NewDetector, AnalyzerBehaviour, ConverterBehaviour).      //

public class SOHolder : MonoBehaviour
{
    public MultijunctionElements element;
}
