
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float verticalSpeed = 0.1f;
    public float runSpeed = 4.5f;

    private Rigidbody rb;
    private AnimatorStateInfo stateInfo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float z = Input.GetAxis("Vertical");

        float h = rotationSpeed * Input.GetAxis("Mouse X");

        z = z * Time.deltaTime * runSpeed;
        transform.Rotate(0, h, 0);


        transform.Translate(-z, 0, 0); // transform the z-postion controlled by keyboard
    }

}
