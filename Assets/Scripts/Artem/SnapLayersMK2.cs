using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLayersMK2 : MonoBehaviour
{
    public GameObject layer;
    public bool layerWriter = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (layerWriter && layer != null)
        {
            if (layer.GetComponent<GrabCheck>().grabbed)
            {
                layer.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Transform childnext = layer.transform.Find("SnapAnchor");
                childnext.gameObject.SetActive(false);
                this.gameObject.GetComponent<Collider>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Layer"))
        {
            Transform child = transform.Find("Ghost");
            child.gameObject.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Layer"))
        {
            Transform child = transform.Find("Ghost");
            child.gameObject.SetActive(false);
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Layer"))
        {
            if (!other.gameObject.GetComponent<GrabCheck>().grabbed)
            {

                other.transform.position = this.transform.position;
                other.transform.rotation = this.transform.rotation;
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                Transform childNext = other.transform.Find("SnapAnchor");
                childNext.gameObject.SetActive(true);
                layer = other.gameObject;
                layerWriter = true;
                Transform child = transform.Find("Ghost");
                child.gameObject.SetActive(false);
                /*Transform ghostNext = other.transform.Find("Ghost");
                ghostNext.gameObject.SetActive(false);*/
                this.gameObject.GetComponent<Collider>().enabled = false;

            }
        }
    }

}
