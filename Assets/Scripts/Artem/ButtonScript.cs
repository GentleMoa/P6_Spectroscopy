using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject sollarPannel;
    public GameObject point;
    public bool buttonPressed = false;
    //private bool spawend = false;
    Animator button_Animator;
    
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
            Invoke("SpawnSollarPannel", 7.5f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftHand" || collision.gameObject.tag == "RightHand")
        {
            Pressed();
 


        }
    }

    private void Pressed()
    {
        button_Animator.SetTrigger("PressProcess");
        ComponentOverseer.Instance.printing = true;
        buttonPressed = false;
    }

    private void SpawnSollarPannel()
    {
        Instantiate(sollarPannel, point.transform.position, Quaternion.identity);
        ComponentOverseer.Instance.printing = false;
    }

}
