using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm_Controller : MonoBehaviour
{
    //Private Variables
    [SerializeField] bool RobotArmsActive = false;
    private GameObject _robotArmTarget;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetRobotArmTargetReference", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(this.gameObject.transform.position, transform.forward, Color.blue, 0.0f);
        if (Physics.Raycast(this.gameObject.transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.collider.gameObject != null)
            {
                if (RobotArmsActive == true)
                {
                    //Update Robot Arms Target object to hit.point
                    _robotArmTarget.transform.position = hit.point;
                }
            }
        }
    }

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

    public void ToggleRobotArm_On()
    {
        if (RobotArmsActive == false)
        {
            RobotArmsActive = true;
        }
    }

    public void ToggleRobotArm_Off()
    {
        if (RobotArmsActive == true)
        {
            RobotArmsActive = false;
        }
    }
}
