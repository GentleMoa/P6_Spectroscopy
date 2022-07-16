using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script handles the following functionalities of the analyzer machine: when an element         //
//  is placed inside, get and display the the element's properties (scriptable object's variables)     //             

public class AnalyzerBehaviour : MonoBehaviour
{
    // Reference canvas objects
    [SerializeField] private TextMeshProUGUI analyzerNameText;
    [SerializeField] private TextMeshProUGUI analyzerEfficiencyText;
    [SerializeField] private Image analyzerImage;

    // Set the text on the Analyzer-canvas on Start() to guide the VR-user
    private void Start()
    {
        analyzerNameText.SetText("Please place your item here to analyze!");
    }

    // Display the information of the element which is placed inside the trigger collider so the VR-user can choose wich element to convert in the next step of the experience, based on the visible information
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Element")) // REPLACE TAG WITH "CollectedElement" WHICH THE ELEMENT WILL HAVE AFTER IT'S BEEN PICKED UP
        {
            analyzerNameText.SetText(other.gameObject.GetComponent<SOHolder>().element.name);                                       // Display the element's name
            analyzerEfficiencyText.SetText("Efficiency: " + other.gameObject.GetComponent<SOHolder>().element.efficiency + "%");    // Display the element's approximate efficiency
            analyzerImage.enabled = false;
        }
    }

    // Reset the information and display the information which was displayed on Start() once the element had been taken out of the Analyzer again
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Element")) // REPLACE TAG WITH "CollectedElement" WHICH THE ELEMENT WILL HAVE AFTER IT'S BEEN PICKED UP
        {
            analyzerNameText.SetText("Please place your item here to analyze!");    // Display the default start-text
            analyzerEfficiencyText.SetText("");
            analyzerImage.enabled = true;                                           // Display an arrow-image pointing towards the Analyzer-collider
        }
    }
}
