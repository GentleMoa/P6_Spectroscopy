using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerShredder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something collides");
        if (other.CompareTag("Layer") && ComponentOverseer.Instance.printing == true)
        {
            Debug.Log("Layer collides");
            Destroy(other.gameObject);
        }
    }
}
