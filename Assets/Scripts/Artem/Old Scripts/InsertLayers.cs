using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertLayers : MonoBehaviour
{
    public GameObject SnapAnchor;
    public List<GameObject> SnapAnchors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("this is update");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "insertable")
        {
            other.transform.position = SnapAnchor.transform.position;
        }
            
    }
}
