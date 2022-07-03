// Created by Krista Plagemann 12.01.22, modified by Sebastian Kostur //

// Cycles through materials to chip away and plays audio and particle on the final destroy hit. //
// Also contains the base class for the materials we can chip away. //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableRock : MonoBehaviour
{
    private int numberOfHits;                           // counter for how many time you hit already
    private int numberOfMaterials;                      // counter of materials you already changed

    public string whatCanDamageThisTag;                 // which Tag can damage this object?
    public List<MaterialsToDestroy> nextMaterials;      // list of all materials we can use
    public Object destroyParticles;                     // particles to spawn on destroy
    public AudioClip destroySound;                      // audio to play on destroy

    // [KP] set hits to 0 at beginning //
    void Start()
    {
        numberOfHits = 0;
        numberOfMaterials = 0;
    }

    // [KP,SK] First cycle through the materials on hit, then do some destroy reaction and destroy this game object. //
    public void hit(Pickaxe pickaxe)
    {
        if (numberOfMaterials < nextMaterials.Count)        // if all the materials have not yet been chopped down
        {
            if (numberOfHits <= nextMaterials[numberOfMaterials].hits)          // if the current material was not hit often enough yet
            {
                numberOfHits++;                                                 // add a hit to our counter
            }
            if (numberOfHits == nextMaterials[numberOfMaterials].hits + 1)      // if current material has been hit often enough
            {
                this.GetComponent<Renderer>().material = nextMaterials[numberOfMaterials].material;     // assign the next material to our object
                numberOfHits = 0;           // set number of hits back to 0 to start fresh on next material
                numberOfMaterials++;        // go to the next material we want to break down with hits
            }
        }
        else
        {
            AudioSource audio = pickaxe.gameObject.GetComponent<AudioSource>();         // get aduios from the axe
            audio.PlayOneShot(destroySound);                                            // then play the destroy sound
            Instantiate(destroyParticles, new Vector3(pickaxe.sparks.gameObject.transform.position.x, pickaxe.sparks.gameObject.transform.position.y, pickaxe.sparks.gameObject.transform.position.z), Quaternion.identity);    // spawn particles
            this.gameObject.GetComponent<Renderer>().enabled = false;   // make this object disappear
            Destroy(this.gameObject);                                   // then destroy it completely
        }
    }
}

// [KP] Stores all the materials we can change to for this object and how many times each must be hit //
[System.Serializable]
public class MaterialsToDestroy
{
    public Material material;       // material we can change to on hitting
    public int hits;                // how many hits it needs to destroy
}