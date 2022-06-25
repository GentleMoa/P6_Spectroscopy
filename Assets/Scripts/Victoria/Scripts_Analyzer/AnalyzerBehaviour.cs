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

    [SerializeField] private TextMeshProUGUI analyzerNameText;
    [SerializeField] private TextMeshProUGUI analyzerEfficiencyText;
    [SerializeField] private Image analyzerImage;

    private void Start()
    {
        analyzerNameText.SetText("Please place your item here to analyze!");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Element")) // REPLACE TAG WITH "CollectedElement" WHICH THE ELEMENT WILL HAVE AFTER IT'S BEEN PICKED UP
        {
            analyzerNameText.SetText(other.gameObject.GetComponent<SOHolder>().element.name);
            analyzerEfficiencyText.SetText("Efficiency: " + other.gameObject.GetComponent<SOHolder>().element.efficiency + "%");
            analyzerImage.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Element")) // REPLACE TAG WITH "CollectedElement" WHICH THE ELEMENT WILL HAVE AFTER IT'S BEEN PICKED UP
        {
            analyzerNameText.SetText("Please place your item here to analyze!");
            analyzerEfficiencyText.SetText("");
            analyzerImage.enabled = true;
        }
    }
}
