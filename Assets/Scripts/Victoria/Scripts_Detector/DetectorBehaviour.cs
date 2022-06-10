using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectorBehaviour : MonoBehaviour
{
    GameObject player;
    GameObject element;

    // variables for the beeping of the detector
    public AudioSource audioS;
    private float slowBeepFrequ = 1f; // time the detector takes before beeping again
    private float mediumBeepFrequ = 0.5f;
    private float fastBeepFrequ = 0.2f;
    private float waitTime;

    private float beepDist1 = 20f;
    private float beepDist2 = 12f;
    private float beepDist3 = 5f;

    private bool afterStart;
    private bool hasCollected;

    private GameObject spawner;
    private GameObject[] elementsRef;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        element = GameObject.FindGameObjectWithTag("Element");
        afterStart = false;
        hasCollected = false;

        spawner = GameObject.FindGameObjectWithTag("Spawner");
        elementsRef = spawner.GetComponent<ElementSpawn>().elements;
    }

    void Update()
    {
        if(!afterStart) // use this bool to let the elements spawn in script "ElementSpawn". Only then, the function DetectElememts can actually find them.
        {
            Invoke("DetectElement", 1f);
            afterStart = true;    
        }
        else
        {
            DetectElement();
        }      
    }

    private void DetectElement()
    {
        float dist;
        dist = Vector3.Distance(player.transform.position, element.transform.position);

        if ((dist <= beepDist1) && (dist >= beepDist2))
        {
            if (waitTime <= 0) // checks if the waiting time is 0 or smaller
            {
                waitTime = slowBeepFrequ; // resets the waiting time to the starting value
                audioS.PlayOneShot(audioS.clip); // play it only once!
            }
            else
            {
                waitTime -= Time.deltaTime; // counts down the waiting time from the start value (which has been set earlier)
            }

            Debug.Log("Element found!");

        }else if((dist <= beepDist2) && (dist >= beepDist3))
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

            // picking the up the element if the player ist close to it
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasCollected = true;
                //CollectorDetector();
                //Destroy(element);   
                ActuallyRemove();
            }
        }
    }

    private void CollectorDetector() // assign a new element to the "element" variable after the previous one has been picked up
    {
        if (hasCollected)
        {
            element = GameObject.FindGameObjectWithTag("Element");
            hasCollected = false;
            Debug.Log("New Element");
        }
    }

    private void RemoveElement<T>(ref T[] arr, int index)
    {
        for(int i = index; i< arr.Length -1; i++)
        {
            arr[i] = arr[i + 1];
        }

        //Array.Resize(ref arr, arr.Length - 1);
    }

    private void ActuallyRemove()
    {
        RemoveElement(ref elementsRef, 0);
        CollectorDetector();
    }


    #region To Do

    // - After after an element is collected, make the script find the next (nearest) element
    // - Make the detector say what the element is:
    //      - put a local canvas on the element detector for displaying the name (use scriptable object for this (get element.name))
    // - Maybe put everything in Update() into a OnTriggerStay() so the image on the detector vanishes when no element is in range (and it's more performant)
    // - Instead of deleting the element GameObject, change it's tag to something different like "Collected" (so that the detector can't find it anymore)

    #endregion
}
