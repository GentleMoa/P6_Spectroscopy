//Code provided by Prof. Dr. Gabler //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class PickAxeHit : MonoBehaviour
{
    private AudioSource myAudioSource;
    public GameObject fxHitPrefab;
    private bool hitActive = false;
    private Vector3 lastHitPos;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 15) // Rock layer
        {
            if (fxHitPrefab && !hitActive)
            {

                hitActive = true;
                // get the first position if the collision as reference to place the FX/particle system at the right place
                lastHitPos = collision.GetContact(0).point;
                
                // if there is an audio source start playing the hit/mining sound
                if (myAudioSource != null)
                {
                    myAudioSource.Play();
                }

                // instantiate the "hit" fx
                GameObject fx = Instantiate(fxHitPrefab, collision.GetContact(0).point, Quaternion.identity);
                Destroy(fx, 1.0f);

                // put haptics here!

            }

        }
    }

    private void Update()
    {
        if (hitActive)
        {
            // minimum distance you need to re-trigger the hit (take a swing to hit)
            if (Vector3.Distance(lastHitPos, transform.position) > 0.8f) 
            {
                hitActive = false;
            }
        }
    }


}
