//---------------------------------------------------------------------------------------------------------------//
//------- Felix Venne - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 12.067.2022 -------//
//---------------------------------------------------------------------------------------------------------------//

// A script enabling the CAVE player to "interact" with grabables via the robot arms

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm_Controller : MonoBehaviour
{
    //Private Variables
    [SerializeField] bool _robotArmsActive = false;
    private GameObject _robotArmTarget;
    private Vector3 _restPos;
    private Vector3 _lastActivePos;
    private bool _restPosDefined = false;
    private float _lerpValue = 0.0f;
    [SerializeField] private float lerpDuration = 1.5f;
    
    void Start()
    {
        Invoke("GetRobotArmTargetReference", 0.1f);
        Invoke("DefineRestPos", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //Updating the IK target to the hit position of a controller raycast
        if (Physics.Raycast(this.gameObject.transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.collider.gameObject != null)
            {
                if (_robotArmsActive == true)
                {
                    //Update Robot Arms Target object to hit.point
                    _robotArmTarget.transform.position = hit.point;
                }
            }
        }

        //Lerping back to rest pos, when inactive
        if (_robotArmsActive == false && _restPosDefined == true)
        {
            if (Vector3.Distance(_restPos, _robotArmTarget.transform.position) > 0.1f)
            {
                //Lerp back to rest pos
                _lerpValue += Time.deltaTime / lerpDuration;
                _robotArmTarget.transform.position = Vector3.Lerp(_lastActivePos, _restPos, _lerpValue);
                Debug.Log(_robotArmTarget.tag + " is now lerping to rest pos!!");
            }
        }
    }

    //Grabbing the respective reference for each of the robot arm IK targets
    private void GetRobotArmTargetReference()
    {
        if (this.gameObject.tag == "LeftController")
        {
            _robotArmTarget = GameObject.FindGameObjectWithTag("RobotArmTarget_L");
        }
        if (this.gameObject.tag == "RightController")
        {
            _robotArmTarget = GameObject.FindGameObjectWithTag("RobotArmTarget_R");
        }
    }

    //Defining the rest postition (to which the robot arms lerp back when inactive)
    private void DefineRestPos()
    {
        _restPos = _robotArmTarget.transform.position;
        _restPosDefined = true;

        //Only for debugging purposes
        //Debug.Log("Rest Position has been defined as: " + _restPos + ", for " + _robotArmTarget.tag);
    }

    //These functions are called on the "Interactable Event" on each of the XR controllers!!
    public void ToggleRobotArm_On()
    {
        if (_robotArmsActive == false)
        {
            _robotArmsActive = true;
            //Reset the _lerpValue take make the lerp work multiple times not just once
            _lerpValue = 0.0f;
        }
    }

    //These functions are called on the "Interactable Event" on each of the XR controllers!!
    public void ToggleRobotArm_Off()
    {
        if (_robotArmsActive == true)
        {
            _robotArmsActive = false;
            //Saving the last active pos of the robotArm IK target
            DefineLastActivePos();
        }
    }

    private void DefineLastActivePos()
    {
        _lastActivePos = _robotArmTarget.transform.position;

        //Only for debugging purposes
        //Debug.Log("Last Active Position has been defined as: " + _lastActivePos + ", for " + _robotArmTarget.tag);
    }
}
