using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ------- SCRIPT BY VICTORIA AMELUNXEN ------- //
//  This script handles the following functionalities of the element detector: determine the distance to the nearest element,    //
//  emit a beeping sound depending on said distance, and displaying the type of the detected element in the UI.                  //

public class NewDetector : MonoBehaviour
{
    // variables important for VR
    private bool detectorGrabbed = true;

    // variables to determine the distance to the nearest element
    private GameObject[] elements;
    private Transform closestElement;  
    private Transform trans = null;
    private float dist;

    // variables for the beeping of the detector
    public AudioSource audioS;
    private float waitTime;
    private float slowBeepFrequ = 1f, mediumBeepFrequ = 0.5f, fastBeepFrequ = 0.2f;
    private float beepDist1 = 15f, beepDist2 = 8f, beepDist3 = 2f;

    // variables for UI
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image canvImg;

    void Start()
    {
        closestElement = null;
    }

    void Update()
    {
        if (detectorGrabbed) // check if the VR player is holding the detector
        {
            closestElement = getClosestElement();
            BeepBoop();
            //Debug.Log(dist);

            canvImg.sprite = closestElement.gameObject.GetComponent<SOHolder>().element.image; // display the image of the closest element's SO on detector UI
            //nameText.SetText(closestElement.gameObject.GetComponent<SOHolder>().element.name); // display the name of the closest element's SO on detector UI
        }      
    }

    public Transform getClosestElement()
    {
        elements = GameObject.FindGameObjectsWithTag("Element"); // find all elements here instead of in Start() so it updates when an element has been collected
        float closestDistance = Mathf.Infinity;
        

        foreach (GameObject go in elements)
        {
            float currentDistance; 
            currentDistance = Vector3.Distance(transform.position, go.transform.position);

            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }

        return trans; // return the transform of the currently closest Element
    }

    private void BeepBoop()
    {
        dist = Vector3.Distance(transform.position, trans.position);

        if ((dist <= beepDist1) && (dist >= beepDist2))
        {
            if (waitTime <= 0)
            {
                waitTime = slowBeepFrequ;
                audioS.PlayOneShot(audioS.clip);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if ((dist <= beepDist2) && (dist >= beepDist3))
        {
            if (waitTime <= 0)
            {
                waitTime = mediumBeepFrequ;
                audioS.PlayOneShot(audioS.clip);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if ((dist <= beepDist2) && (dist <= beepDist3))
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
