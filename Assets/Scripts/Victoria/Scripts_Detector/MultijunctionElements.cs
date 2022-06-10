using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This is a sriptable object (SO) template which goes on the "SOHolder" script on every Element-Prefab   //
//  where the variavles are filled in to match the element's individual properties.                        //

[CreateAssetMenu(fileName = "NewElement", menuName = "Element/NewElement")]
public class MultijunctionElements : ScriptableObject
{
    public new string name;
    public Sprite image;
    public string absorbingWavelegth;
    public string[] conpatibleWithElements;

}