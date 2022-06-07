using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLayers : MonoBehaviour
{
    private void Start()
    {
    
    }

    private 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "insertable")
        {
            string objectName = other.gameObject.name;
            string layerName = this.gameObject.name;
            other.transform.position = this.transform.position;
            other.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Layer Name __ " + layerName + "; Material Name __ " + objectName);
            //ComponentOverseer.Instance.EnergyCheck();



            if (this.name == "Layer0")
            {
                ComponentOverseer.Instance.Layer0 = this.name;
                
            }
            if (this.name == "Layer1")
            {
                ComponentOverseer.Instance.Layer1 = this.name;
                
            }
            if (this.name == "Layer2")
            {
                ComponentOverseer.Instance.Layer2 = this.name;
                
            }
            if (this.name == "Layer3")
            {
                ComponentOverseer.Instance.Layer3 = this.name;
                
            }
            if (this.name == "Layer4")
            {
                ComponentOverseer.Instance.Layer4 = this.name;
                
            }
            if (this.name == "Layer5")
            {
                ComponentOverseer.Instance.Layer5 = this.name; 
                
            }








            //Debug.Log(this.gameObject.name);
            //for(int i =0; i < ComponentOverseer.Instance.Layers.Capacity; i++)
            //{
            //    if (this.name == ComponentOverseer.Instance.Layers[i])
            //    {
            //        //Debug.Log("this is Layer №" + i);

            //    }
            //    Debug.Log("Hello " + i);
            //    Debug.Log(ComponentOverseer.Instance.Components[i]);
            //}










        }

    }
}
