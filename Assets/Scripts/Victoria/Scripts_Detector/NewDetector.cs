using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script handles the following functionalities of the element Detector: determine the distance to the nearest element,    //
//  emit a beeping sound depending on said distance, and displaying an image of the detected element in the Detector's UI.       //

public class NewDetector : MonoBehaviour
{
    // Variables for VR
    private bool detectorGrabbed = true;

    // Variables to determine the distance to the nearest element
    private GameObject[] elements;
    private Transform closestElement;  
    private Transform trans = null;
    private float dist;

    // Variables for the beeping of the detector
    public AudioSource audioS;
    private float waitTime;
    private float slowBeepFrequ = 1f, mediumBeepFrequ = 0.5f, fastBeepFrequ = 0.2f;
    private float beepDist1 = 15f, beepDist2 = 8f, beepDist3 = 2f;

    // Variables for UI
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image canvImg;

    void Start()
    {
        closestElement = null;
    }

    void Update()
    {
        // Check if the VR player is holding the detector
        if (detectorGrabbed)
        {
            closestElement = getClosestElement();
            BeepBoop();

            canvImg.sprite = closestElement.gameObject.GetComponent<SOHolder>().element.image; // Display the image of the closest element's SO on detector UI
            //nameText.SetText(closestElement.gameObject.GetComponent<SOHolder>().element.name); // Display the name of the closest element's SO on detector UI
        }      
    }

    public Transform getClosestElement()
    {
        elements = GameObject.FindGameObjectsWithTag("Element"); // Find all elements here instead of in Start() so it updates when an element has been collected

        float closestDistance = Mathf.Infinity; // Determine the range in which the Detector searches for elements (biggest range possible!)
        
        foreach (GameObject go in elements)
        {
            float currentDistance; 
            currentDistance = Vector3.Distance(transform.position, go.transform.position); // Store the distance to each element

            if(currentDistance < closestDistance)   // If the element is in range...
            {
                closestDistance = currentDistance;  // ... store the distance...
                trans = go.transform;               // ... and store the transform of said closest element 
            }
        }

        return trans; // Return the transform of the currently closest Element of which the image will be displayed on the Detector to guide the VR-user
    }

    // Function for handling the beeping-sound of the Detector
    private void BeepBoop()
    {
        dist = Vector3.Distance(transform.position, trans.position);

        if ((dist <= beepDist1) && (dist >= beepDist2))  // If the distance between the Detector and the Element is still quite large
        {
            if (waitTime <= 0)
            {
                waitTime = slowBeepFrequ;        // Determine the time in between beeps
                audioS.PlayOneShot(audioS.clip); // Play the beep (only once!)
            }
            else
            {
                waitTime -= Time.deltaTime;      // Count down the time before the next beep
            }
        }
        else if ((dist <= beepDist2) && (dist >= beepDist3)) // If the distance between the Detector and the Element is moderate
        {
            if (waitTime <= 0)
            {
                waitTime = mediumBeepFrequ;
                //audioS.PlayOneShot(audioS.clip);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if ((dist <= beepDist2) && (dist <= beepDist3)) // If the distance between the Detector and the Element is small
        {
            if (waitTime <= 0)
            {
                waitTime = fastBeepFrequ;
                audioS.PlayOneShot(audioS.clip);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

            // picking the up the element if the player ist close to it (replace KeyCode.Space later for VR)
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    Debug.Log("Has Collected");
            //    getClosestElement().gameObject.tag = "CollectedElement"; // change the tag of the collected element so it's longer being detected by the detector
            //}
        }
        else
        {
            return;
        }
    }
}
