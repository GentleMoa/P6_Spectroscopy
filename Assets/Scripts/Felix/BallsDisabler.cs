using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallsDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<PhotonView>().IsMine == false)
        {
            Destroy(this.gameObject);
        }
    }
}
