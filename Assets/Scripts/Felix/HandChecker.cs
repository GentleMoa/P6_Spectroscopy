using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandChecker : MonoBehaviour
{
    //Private Variables
    [SerializeField] private GameObject _leftController;
    [SerializeField] private GameObject _rightController;
    [SerializeField] private GameObject _leftHand;
    [SerializeField] private GameObject _rightHand;
    [SerializeField] private bool _leftHandFound = false;
    [SerializeField] private bool _rightHandFound = false;
    [SerializeField] private bool _handsParented = false;

    // Start is called before the first frame update
    //void Start()
    //{
    //    _leftController = GameObject.FindGameObjectWithTag("LeftController");
    //    _rightController = GameObject.FindGameObjectWithTag("RightController");
    //}

    // Update is called once per frame
    void Update()
    {
        if (_leftHandFound == false || _rightHandFound == false)
        {
            _leftHand = GameObject.FindGameObjectWithTag("LeftHand");
            _rightHand = GameObject.FindGameObjectWithTag("RightHand");

            if (_leftHand != null)
            {
                _leftHandFound = true;
            }
            else if (_leftHand == null)
            {
                Debug.Log("LeftHand Prefab has not been found yet!");
            }

            if (_rightHand != null)
            {
                _rightHandFound = true;
            }
            else if (_rightHand == null)
            {
                Debug.Log("RightHand Prefab has not been found yet!");
            }
        }
        else if (_leftHandFound == true && _rightHandFound == true && _handsParented == false)
        {
            if (_leftHand.GetComponent<PhotonView>().IsMine == false && _rightHand.GetComponent<PhotonView>().IsMine == false)
            {
                //_leftController = GameObject.FindGameObjectWithTag("LeftController");
                //_rightController = GameObject.FindGameObjectWithTag("RightController");
                _leftController = GameObject.Find("LeftHand Controller");
                _rightController = GameObject.Find("RightHand Controller");

                Invoke("HandParenting", 1.0f);

                //if (_leftController != null && _rightController != null)
                //{
                //    _leftHand.transform.SetParent(_leftController.transform);
                //    _rightHand.transform.SetParent(_rightController.transform);
                //
                //    _handsParented = true;
                //}
                //else
                //{
                //    Debug.LogWarning("VR Controllers have not been found!");
                //}
            }
        }
    }

    private void HandParenting()
    {
        if (_leftController != null && _rightController != null)
        {
            _leftHand.transform.SetParent(_leftController.transform);
            _rightHand.transform.SetParent(_rightController.transform);

            _handsParented = true;
        }
        else
        {
            Debug.LogWarning("VR Controllers have not been found!");
        }
    }
}
