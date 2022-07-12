using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Kick : MonoBehaviour
{
    public Vector3 impulse = new Vector3(-6.0f, 0.0f, 0.0f);
    Rigidbody sp_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Awake()
    {
        GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
    }
}
