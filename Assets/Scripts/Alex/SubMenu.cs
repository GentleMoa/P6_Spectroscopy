//---------------------------------------------------------------------------------------------------------------//
//-------Alex Zarenko - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project ---------------------//
//---------------------------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour
{
    public string menuName;
    public bool open;

    // simple open function that is used in the MenuManager Script
    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    // simple close function that is used in the MenuManager Script
    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}
