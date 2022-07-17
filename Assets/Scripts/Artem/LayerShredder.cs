// Created by Artem Brodetskii 28.06.22 //
// Destroys the layers of the solar panel lying inside the press during printing //
//--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------//
//--------------------------------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerShredder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("something collides");
        if (other.CompareTag("Layer") && ComponentOverseer.Instance.printing == true)
        {
            Debug.Log("Layer collides");
            Destroy(other.gameObject);
        }

    }
}
