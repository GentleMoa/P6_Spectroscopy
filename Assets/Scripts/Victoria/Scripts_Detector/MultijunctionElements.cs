using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This is a sriptable object (SO) template which goes in the "SOHolder" script on every Element-Prefab   //
//  where the variavles are filled in to match the element's individual properties.                        //

[CreateAssetMenu(fileName = "NewElement", menuName = "Element/NewElement")]
public class MultijunctionElements : ScriptableObject
{
    public new string name;     // The name of the element (e.g. "Si (Silicon)") which will be displayed on the Analyzer-Machine to determine the type of element
    public Sprite image;        // An image of the element which will be displayed on the Metal-Detector to help the VR-user find the element inside the rock before it's been excavated
    public string efficiency;   // The filled in numbers are not 100% physically accurate but they help the VR-user to determine if the element is worth being processed further by the Converter
    public GameObject layer;    // The corresponding junction-layer which will be spawned inside the Converter-Machine (the element is being "converted" into the respective layer)
}