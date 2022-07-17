//---------------------------------------------------------------------------------------------------------------//
//-------Alex Zarenko - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project ---------------------//
//---------------------------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Singleton Pattern
    public static MenuManager Instance;

    [SerializeField] SubMenu[] menus;

    void Awake()
    {
        Instance = this;
    }


    // making sure to close all other SubMenus, when opening a new one
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            // calling SubMenus by their Names, to call their .Open(); function
            if(menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            // if a SubMenu is already opened, close it
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(SubMenu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    public void CloseMenu(SubMenu menu)
    {
        menu.Close();
    }
}
