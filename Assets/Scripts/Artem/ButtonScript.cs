using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ButtonScript : MonoBehaviour
{
    public GameObject sollarPannel;
    public GameObject point;
    public bool buttonPressed = false;
    Animator button_Animator;
    //public bool printingOngoing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        button_Animator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            Pressed();
            Invoke("SpawnSollarPannel", 11.5f);

        }
    }

    public void Pressed()
    {
        //if (printingOngoing == false)
        //{
        //    //printingOngoing = true;
        //    button_Animator.SetTrigger("PressProcess");
        //    ComponentOverseer.Instance.printing = true;
        //    buttonPressed = false;
        //}

        //printingOngoing = true;
        button_Animator.SetTrigger("PressProcess");
        ComponentOverseer.Instance.printing = true;
        buttonPressed = false;
    }

    private void SpawnSollarPannel()
    {
        //Instantiate(sollarPannel, point.transform.position, Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPanels", "SolarPanelHolder"), point.transform.position, Quaternion.identity);
        ComponentOverseer.Instance.printing = false;
        //printingOngoing = false;
    }

}
