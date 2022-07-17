// Created by Artem Brodetskii 28.06.22 //
// Starts the solar panel printing process //
//--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ButtonScript : MonoBehaviour
{
    public GameObject sollarPannel;
    public GameObject point;
    public bool buttonPressed = false;
    Animator button_Animator;
    
    void Start()
    {
        button_Animator = gameObject.GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (buttonPressed)
        {
            Pressed();
            Invoke("SpawnSollarPannel", 11.5f);

        }
    }

    public void Pressed()
    {
        button_Animator.SetTrigger("PressProcess");
        ComponentOverseer.Instance.printing = true;

        buttonPressed = false;

        Invoke("SpawnSollarPannel", 11.5f);
    }

    private void SpawnSollarPannel()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", "SolarPanelHolder"), point.transform.position, Quaternion.identity);
        ComponentOverseer.Instance.printing = false;
    }

}
